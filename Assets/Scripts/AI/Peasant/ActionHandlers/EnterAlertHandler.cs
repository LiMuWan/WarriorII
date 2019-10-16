using BlueGOAP;
using Game.AI.Model;
using Game.AI.ViewEffect;

namespace Game.AI
{
    public class EnterAlertHandler : HandlerBase<EnterAlertModel>
    {
        public EnterAlertHandler(IAgent<ActionEnum, GoalEnum> agent, IMaps<ActionEnum, GoalEnum> maps, IAction<ActionEnum> action) : base(agent, maps, action)
        {
           
        }
    }
}
