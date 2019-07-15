using Entitas;
using Game;
using Game.Service;
using System.Collections.Generic;

/// <summary>
/// 判断技能按钮输入的是否有效
/// </summary>
public class InputJudgeHumanSkillSystem:ReactiveSystem<InputEntity>,IInitializeSystem
{
    protected Contexts contexts;

    public   InputJudgeHumanSkillSystem(Contexts contexts): base(contexts.input)    
    {
        this.contexts = contexts;
    }

    public void Initialize()
    {
        contexts.input.ReplaceGameInputValidHumanSkill(false, 0);
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
        foreach (var entity in entities)
        {
            ITimerService timerService = contexts.service.gameServiceTimerService.TimerService;
            var timer = timerService.CreateTimer(Const.TimerId.HUMAN_SKILL_TIMER, 0.2f, false);
            if (timer == null)
            {
                timer = timerService.ResetTimerData(Const.TimerId.HUMAN_SKILL_TIMER, 0.2f, false);
                timer.AddCompleteListener(() => SetValid(entity,true));
            }
            else
            {
                timer.AddCompleteListener(() => SetValid(entity, true));
            }

            SetValid(entity, false);
        }
    }

    private void SetValid(InputEntity entity, bool isValid)
    {
        var skillComponent = contexts.input.gameInputValidHumanSkill;
        ReplaceValidHumanSkill(entity, isValid, skillComponent);
    }

    private void ReplaceValidHumanSkill(InputEntity entity,bool isValid, InputValidHumanSkillComponent skillComponent)
    {
        int code = 0;
        if(skillComponent != null)
        {
            code = skillComponent.SkillCode;
        }

        code = contexts.service.gameServiceSkillCodeService.SkillCodeService.
          GetCurrentSkillCode(entity.gameInputButton.InputButton, code);
        contexts.input.ReplaceGameInputValidHumanSkill(isValid, code);
    }

    
}
