using BlueGOAP;
using Game.AI.Model;
using Game.AI.ViewEffect;
using Game.Service;
using Module.Timer;

namespace Game.AI
{
    public class ExitAlertHandler : HandlerBase<EnterAlertModel>
    {
        public ExitAlertHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
           
        }
    }
}
