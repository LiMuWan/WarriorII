using Const;
using UnityEngine;
using UnityEngine.UI;

namespace UIFrame
{
    public class StartGameView : BasicUI  
    {
        public override UiId GetUiId()
        {
            return UiId.StartGame;
        }

        public void Start()        
        {
            //transform.Find("Buttons/Continue").GetComponent<Button>().onClick.AddListener();
            //transform.Find("Buttons/Easy").GetComponent<Button>().onClick.AddListener();
            //transform.Find("Buttons/Normal").GetComponent<Button>().onClick.AddListener();
            //transform.Find("Buttons/Hard").GetComponent<Button>().onClick.AddListener();
        }
    }
}
