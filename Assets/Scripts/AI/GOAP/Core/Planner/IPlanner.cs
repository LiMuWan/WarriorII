using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GOAP
{
    public interface IPlanner<TAction,TGoal>
    {
        Queue<IActionHandler<TAction>> BuildPlan(IGoal<TGoal> goal);
    }

    public class Planner<TAction, TGoal> : IPlanner<TAction, TGoal>
    {
        private IAgent<TAction, TGoal> _agent;

        public Planner(IAgent<TAction, TGoal> agent)
        {
            _agent = agent;
        }

        public Queue<IActionHandler<TAction>> BuildPlan(IGoal<TGoal> goal)
        {
            Queue<IActionHandler<TAction>> plan = new Queue<IActionHandler<TAction>>();

            if (goal == null)
                return plan;

            TreeNode<TAction> currentNode = Plan(goal);
            if(currentNode == null)
            {
                TAction label = _agent.ActionManager.GetDefaultActionLable();
                plan.Enqueue(_agent.ActionManager.GetHandler(label));
                DebugMsg.LogError("当前节点为空，设置当前动作为默认动作");
                return plan;
            }

            while (currentNode.ID != TreeNode<TAction>.DEFAULT_ID)
            {
                plan.Enqueue(currentNode.ActionHandler);
                currentNode = currentNode.ParentNode;
            }

            DebugMsg.Log("计划完成"); 
        }

        private TreeNode<TAction> Plan(IGoal<TGoal> goal)
        {
            Tree<TAction> tree = new Tree<TAction>();
            TreeNode<TAction> topNode = CreateTopNode(tree,goal);
            TreeNode<TAction> currentNode = topNode;
            TreeNode<TAction> subNode = null;
            while (! IsEnd(currentNode))
            {
                List<IActionHandler<TAction>> handlers = GetSubHandlers(currentNode);
                foreach (IActionHandler<TAction> handler in handlers)
                {
                    subNode = tree.CreateNormalNode(handler);
                    SetSubNodeState(currentNode, subNode);
                }
            }
        }

        private void SetSubNodeState(TreeNode<TAction> currentNode, TreeNode<TAction> subNode)
        {
            if(subNode.ID > TreeNode<TAction>.DEFAULT_ID)
            {
                IAction<TAction> subAction = subNode.ActionHandler.Action;
                currentNode.CopyState(subNode);
                IState data = currentNode.GoalState.GetSameData(subAction.Effects);
                subNode.CurrentState.Set(data);
                subNode.GoalState.Set(subAction.Preconditions);
                SetNodeCurrentState(subNode);
            }
            else
            {
                DebugMsg.LogError("此部分逻辑，节点不能为头节点!!!");
            }
        }

        private List<IActionHandler<TAction>> GetSubHandlers(TreeNode<TAction> node)
        {
            List<IActionHandler<TAction>> handlers = new List<IActionHandler<TAction>>();

            if (node == null)
                return handlers;
            //获取到状态差异的所有键值
            var keys = node.CurrentState.GetValueDifference(node.GoalState);
            var map = _agent.ActionManager.EffectsAndActionMap;

            //对比所有的动作
            //找到能实现当前键值的动作
            //也就action的effects中包含此键值
            foreach (string key in keys)
            {
                if(map.ContainsKey(key))
                {
                    foreach (IActionHandler<TAction> handler in map[key])
                    {
                        if(!handlers.Contains(handler))
                        {
                            handlers.Add(handler);
                        }
                    }
                }
                else
                {
                    DebugMsg.LogError("当前没有动作能够从当前状态切换到目标状态，无法实现的键值为： " + key);
                }
            }

            handlers.OrderByDescending(u => u.Action.Priority).ToList();

            return handlers;
        }

        private bool IsEnd(TreeNode<TAction> currentNode)
        {
            if (currentNode == null)
                return true;

            if (GetStateDifferentNum(currentNode) == 0)
            {
                DebugMsg.Log("查找动作部分结束");
                return true;
            }

            return false;
        }

        private int GetStateDifferentNum(TreeNode<TAction> currentNode)
        {
            return currentNode.CurrentState.GetValueDifference(currentNode.GoalState).Count;
        }

        private TreeNode<TAction> CreateTopNode(Tree<TAction> tree,IGoal<TGoal> goal)
        {
            TreeNode<TAction> topNode = tree.CreateTopNode();
            topNode.GoalState.Set(goal.GetEffects());
            SetNodeCurrentState(topNode);

            return topNode;
        }

        private void SetNodeCurrentState(TreeNode<TAction> node)
        {
            //goal当中存在 current当中不存在 获取这样的键值
            //通过键值 在agentState当中获取数据
            var keys = node.CurrentState.GetNotExistKeys(node.GoalState);
            foreach (var key in keys)
            {
                node.CurrentState.Set(key, _agent.AgentState.Get(key));
            }
        }
    }
}
