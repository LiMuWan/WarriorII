using BlueGOAP;
using Game.AI.ViewEffect;
using Game.Service;
using Module.Timer;

namespace Game.AI
{
    public class EnterAlertHandler : ActionHandlerBase<ActionEnum, GoalEnum>
    {
        private AlertModel _model;
        private ITimerService _timerService;
        private ITimer _timer;

        public EnterAlertHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
            _model =this.GetModel<AlertModel>(maps);
            _timerService = Contexts.sharedInstance.service.gameServiceTimerService.TimerService;
        }

        public override void Enter()
        {
            base.Enter();
            DebugMsg.Log("进入警戒状态");
            _timer = _timerService.CreateOrRestartTimer(Label.ToString() + ID, _model.ShowSwordDuration, false);
            _timer.AddCompleteListener(() => OnComplete());
        }
    }
}
