using UnityEngine;
using BlueGOAP;
using Game.Service;
using Module.Timer;
using Game.AI.ViewEffect;

namespace Game.AI
{
    public class IdleSwordHandler : HandlerBase<IModel>
    {
        private static int _times;
        private int _id;

        public IdleSwordHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
            IsNeedResetPreconditions = false;
            _id = _times++;
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入攻击待机状态");
            CreateTimer(Const.IDLE_SWORD_DELAY_TIME);
        }
    }
}
