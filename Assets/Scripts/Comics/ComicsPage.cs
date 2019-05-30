using UnityEngine;
using UnityEngine.UI;
using Util;

namespace UIFrame
{
    public class ComicsPage : MonoBehaviour    
    {
        private Sprite[] numSprites;
        private Image indexImage;
        private void Start()        
        {
            numSprites = transform.GetComponent<NumSprites>().numSprites;
            indexImage = transform.Find("Index").Image();
        }

        public void ShowNum(int index)
        {
            if(index >= numSprites.Length)
            {
                Debug.LogError("Index > numSprites Length");
                return;
            }
            else
            {
                indexImage.sprite = numSprites[index];
            }
        }
    }
}
