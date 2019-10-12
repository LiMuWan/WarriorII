using BlueGOAP;
using Game.Service;
using Module.Timer;

namespace Game.AI.ViewEffect
{
    public abstract class HandlerBase<TModel> : ActionHandlerBase<ActionEnum, GoalEnum> where TModel : class , IModel
    {
        protected ITimerService _timerService;
        protected ITimer _timer;
        protected TModel _model;

        public HandlerBase(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
            _model = this.GetModel<TModel>(maps);
            _timerService = Contexts.sharedInstance.service.gameServiceTimerService.TimerService;
        }

        protected TClass GetGameData<TClass>(GameDataKeyEnum key) where TClass : class
        {
            return GetGameData<GameDataKeyEnum, TClass>(key);
        }

        protected TValue GetGameDataValue<TValue>(GameDataKeyEnum key) where TValue : struct
        {
            return GetGameDataValue<GameDataKeyEnum, TValue>(key);
        }

        public override void Enter()
        {
            base.Enter();

            if (_model != null && _model.AniDuration > 0)
            {
                CreateTimer(_model.AniDuration);
            }
        }

        protected void CreateTimer(float duration , bool loop = false)
        {
            _timer = _timerService.CreateOrRestartTimer(Label.ToString() + ID, duration, false);
            _timer.AddCompleteListener(() => OnComplete());
        }

        public override void Exit()
        {
            base.Exit();
            if(_timer != null)
            {
                _timerService.StopTimer(_timer, false);
            }
        }
    }
}
