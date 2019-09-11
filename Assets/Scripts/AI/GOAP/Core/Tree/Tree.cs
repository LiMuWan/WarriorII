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

        public IState CurrentState { get; set; }

        public IState GoalState { get; set; }

        public int Cost { get; set; }

        public TreeNode<TAction> ParentNode { get; set; }

        public TreeNode(IActionHandler<TAction> actionHandler)
        {
            ID = _id++;
            ActionHandler = actionHandler;
            Cost = 0;
            ParentNode = null;
            CurrentState = new State();
            GoalState = new State();
        }

        public void Reset()
        {
            _id = 0;
        }
    }
}
