using Const;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Util;
using Manager;

namespace UIFrame
{
    public class ComicsManager : MonoBehaviour    
    {
        private readonly Dictionary<ComicsParentId, Transform> parentDic = new Dictionary<ComicsParentId, Transform>();
        private readonly Stack<ComicsItem> leftStack = new Stack<ComicsItem>();
        private readonly Stack<ComicsItem> rightStack = new Stack<ComicsItem>();
        private ComicsPage comicsPage;
        private void Start()        
        {
            InitParent();
            InitButtons();
            SpawItem();
            InitPage();
            InitBGAudio();
        }

        private void InitPage()
        {
            comicsPage = transform.GetByName("Page").GetOrAddComponent<ComicsPage>();
        }

        private void InitBGAudio()
        {
            var manager = gameObject.AddComponent<UIAudioManager>();
            manager.Init(Path.BG_AUDIO_PATH, LoadManager.Single.LoadAll<AudioClip>);
            manager.PlayBG(BGAudioName.Level_Bg.ToString());
        }

        private void InitParent()
        {
            Transform parent = transform.GetByName("Parent");
            Transform temp;
            foreach (ComicsParentId id in Enum.GetValues(typeof(ComicsParentId)))
            {
                var list = from Transform child in parent where child.name.Contains(id.ToString()) select child;
                temp = list.FirstOrDefault();
                if (temp == null)
                {
                    Debug.LogError("can not find child name :" + id);
                    continue;
                }
                else
                {
                    parentDic[id] = temp;
                }
            }
        }

        private void InitButtons()
        {
            transform.AddBtnListener("Back", Back);
            transform.AddBtnListener("Left", LeftBtn);
            transform.AddBtnListener("Right", RightBtn);
            transform.AddBtnListener("Done", () => 
            {
                StartCoroutine(LoadSceneManager.Single.LoadSceneAsync(DataManager.Single.GetSceneName()));
                LoadSceneManager.Single.AllowSwitchScene();
            });
        }

        private void LeftBtn()
        {
            if (rightStack.Count == 0) return;

            ComicsItem temp = Move(ComicsParentId.LeftComics);
            comicsPage.ShowNum(temp.Page);
        }

        private void RightBtn()
        {
            if (leftStack.Count == 0) return;

            ComicsItem temp = Move(ComicsParentId.RightComics);
            comicsPage.ShowNum(temp.Page);
        }

        private void Back()
        {
            ComicsItem temp = null;
            temp = GetCurrentItem();
            ResetToRight(temp);

            int count = leftStack.Count;
            for (int i = 0; i < count; i++)
            {
                temp = leftStack.Pop();
                ResetToRight(temp);
            }
            temp = rightStack.Pop();
            temp.SetParentAndPosition(parentDic[ComicsParentId.CurrentComics]);
            comicsPage.ShowNum(temp.Page);
        }

        private void ResetToRight(ComicsItem item)
        {
            item.SetParentAndPosition(parentDic[ComicsParentId.RightComics]);
            rightStack.Push(item);
        }

        private void SpawItem()
        {
            var sprites = GetSprites();
            SpawCurrentItem(sprites);
            SpawRightItem(sprites);
        }

        private void SpawCurrentItem(List<Sprite> sprites)
        {
            if (parentDic[ComicsParentId.CurrentComics].childCount == 0)
            {
                InitItem(parentDic[ComicsParentId.CurrentComics], sprites[0], 0);
            }
        }

        private void SpawRightItem(List<Sprite> sprites)
        {
            ComicsItem temp;
            for (int i = sprites.Count - 1; i > 0; i--)
            {
                temp = InitItem(parentDic[ComicsParentId.RightComics], sprites[i], i);
                rightStack.Push(temp);
            }
        }

        private ComicsItem InitItem(Transform parent, Sprite sprite, int page)
        {
            GameObject temp = LoadManager.Single.LoadAndInstantiate(Const.Path.COMICS_ITEM_PREFAB_PATH, parent);
            ComicsItem item = temp.AddComponent<ComicsItem>();
            item.Init(sprite, page);
            return item;
        }

        private List<Sprite> GetSprites()
        {
            string path = Path.COMICS_PATH + ((int)DataManager.Single.LevelIndex).ToString("00");
            return LoadManager.Single.LoadAll<Sprite>(path).ToList();
        }
        private ComicsItem Move(ComicsParentId id)
        {
            ComicsItem current = GetCurrentItem();
            ComicsItem side = null;
            switch (id)
            {
                case ComicsParentId.LeftComics:
                    leftStack.Push(current);
                    side = rightStack.Pop();
                    break;
                case ComicsParentId.RightComics:
                    rightStack.Push(current);
                    side = leftStack.Pop();
                    break;
            }
            current.Move(parentDic[id]);
            side.Move(parentDic[ComicsParentId.CurrentComics]);
            return side;
        }

        private ComicsItem GetCurrentItem()
        {
            return parentDic[ComicsParentId.CurrentComics].GetChild(0).GetComponent<ComicsItem>();
        }
    }
}
