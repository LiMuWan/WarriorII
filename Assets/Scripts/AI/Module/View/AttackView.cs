using BlueGOAP;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AttackView : IFsmState<ActionEnum>
    {
        public ActionExcuteState ExcuteState { get; }

        public ActionEnum Label { get { return ActionEnum.ATTACK; } }

        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
