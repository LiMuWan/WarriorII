using Entitas;
using Game.Service;
using System.Collections.Generic;

/// <summary>
/// 人物技能输入状态响应类
/// </summary>
public class InputHumanSkillStateSystem:ReactiveSystem<InputEntity>, IInitializeSystem
{
    protected Contexts contexts;

    public InputHumanSkillStateSystem(Contexts contexts) : base(contexts.input)
    {
        this.contexts = contexts;
    }

    public void Initialize()
    {
        contexts.input.ReplaceGameInputHumanSkillState(false, 0);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.GameInputButton);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.gameInputButton.InputButton == Game.InputButton.ATTACK_X
            || entity.gameInputButton.InputButton == Game.InputButton.ATTACK_O;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity in entities)
        {
            ITimerService timerService = contexts.service.gameServiceTimerService.TimerService;
            var timer = timerService.CreateOrRestartTimer(Const.TimerId.HUMAN_SKILL_TIMER, 0.2f, false);
            timer.AddCompleteListener(() => SetValid(entity, true));
            SetValid(entity, false);
        }
    }

    private void SetValid(InputEntity entity, bool isEnd)
    {
        var skillComponent = contexts.input.gameInputHumanSkillState;
        ReplaceValidHumanSkill(entity, isEnd, skillComponent);
    }

    private void ReplaceValidHumanSkill(InputEntity entity, bool isValid, Game.InputHumanSkillStateComponent skillComponent)
    {
        int code = 0;
        if (skillComponent != null)
        {
            code = skillComponent.SkillCode;
        }

        if (!isValid)
        {
            isValid = JudgeIsMaxLength(code);
        }

        if (!isValid)
        {
            code = contexts.service
                .gameServiceSkillCodeService.SkillCodeService
                .GetCurrentSkillCode(entity.gameInputButton.InputButton, code);
        }
        contexts.input.ReplaceGameInputHumanSkillState(isValid, code);
    }

    /// <summary>
    /// 对比编码长度，等于最大长度返回true
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    private bool JudgeIsMaxLength(int code)
    {
        int maxLength = contexts.game.gameModelHumanSkillConfig.LengthMax;
        return code.ToString().Length == maxLength;
    }
}
