using Entitas;
using Game.Service;
using System.Collections.Generic;

/// <summary>
/// 判断技能按钮输入的是否有效
/// </summary>
public class InputJudgeHumanSkillSystem:ReactiveSystem<InputEntity> 
{
    protected Contexts contexts;
    private bool isValid;

    public   InputJudgeHumanSkillSystem(Contexts contexts): base(contexts.input)    
    {
        this.contexts = contexts;
    }

    protected  override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)     
    {
        return context.CreateCollector(InputMatcher.GameInputButton);
    }

    protected  override bool Filter(InputEntity entity)    
    {
        return entity.gameInputButton.InputButton == Game.InputButton.ATTACK_X
            || entity.gameInputButton.InputButton == Game.InputButton.ATTACK_O;
    }

    protected  override void Execute(List<InputEntity> entities)    
    {
        ITimerService timerService = contexts.service.gameServiceTimerService.TimerService;
        var timer = timerService.CreateTimer(Const.TimerId.HUMAN_SKILL_TIMER, 0.2f, false);
        timer.AddCompleteListener(() => SetValid(false));
        if(timer != null)
        {
            timerService.ResetTimerData(Const.TimerId.HUMAN_SKILL_TIMER, 0.2f, false);
            timer.AddCompleteListener(() => SetValid(false));
        }

        if(isValid)
        {

        }
    }

    private void SetValid(bool isValid)
    {
        this.isValid = isValid;
    }
}
