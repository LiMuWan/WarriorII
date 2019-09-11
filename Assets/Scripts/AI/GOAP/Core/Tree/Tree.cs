using UnityEngine;

namespace GOAP
{
    public class Tree<TAction>    
    {
        
    }

    public class TreeNode<TAction>
    {
        public  static int _id ;

        public int ID { get; private set; }
       
        public IActionHandler<TAction> ActionHandler { get; private set; }

        public TreeNode(IActionHandler<TAction> actionHandler)
        {
            ID = _id++;
            ActionHandler = actionHandler;
        }

        public void Reset()
        {
            _id = 0;
        }
    }
}
