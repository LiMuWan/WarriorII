using UnityEngine;

namespace GOAP
{
    public class Tree<TAction>    
    {
        public TreeNode<TAction> CreateTopNode()
        {
            TreeNode<TAction>.Reset();
            return new TreeNode<TAction>(null);
        }

        public TreeNode<TAction> CreateNormalNode(IActionHandler<TAction> actionHandler)
        {
            if (actionHandler == null)
                DebugMsg.LogError("动作不能为空！");
            return new TreeNode<TAction>(actionHandler);
        }
    }

    public class TreeNode<TAction>
    {
        public const int DEFAULT_ID = 0;

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
            CurrentState = CurrentState.CreateState() ;
            GoalState = GoalState.CreateState();
        }

        public static void Reset()
        {
            _id = DEFAULT_ID;
        }
    }
}
