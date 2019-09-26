using UnityEngine;
using BlueGOAP;
using Game.Service;
using Module.Timer;

namespace Game.AI
{
    public class IdleSwordHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        ITimerService _timerService;
        ITimer _timer;

        public IdleSwordHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
            IsNeedResetPreconditions = false;
            _timerService = Contexts.sharedInstance.service.gameServiceTimerService.TimerService;
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入攻击待机状态");
            _timer = _timerService.CreateOrRestartTimer("IdleSwordHandler", Const.IDLE_SWORD_DELAY_TIME, false);
            _timer.AddCompleteListener(() => OnComplete());
        }

        public override void Exit()
        {
            base.Exit();
            _timerService.StopTimer(_timer, false);
        }
    }
}
