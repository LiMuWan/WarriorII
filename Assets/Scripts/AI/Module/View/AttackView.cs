using BlueGOAP;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public class AttackView<T> : IFsmState<T>
    {
        public ActionExcuteState ExcuteState { get; }

        public T Label { get; }

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
