using Entitas;
using Game;
using Game.Model;
using Game.Service;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 判断技能按钮输入的是否有效
/// </summary>
public class InputJudgeHumanSkillSystem:ReactiveSystem<InputEntity>
{
    protected Contexts contexts;

    public   InputJudgeHumanSkillSystem(Contexts contexts): base(contexts.input)    
    {
        this.contexts = contexts;
    }

    protected  override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)     
    {
        return context.CreateCollector(InputMatcher.GameInputHumanSkillState);
    }

    protected  override bool Filter(InputEntity entity)    
    { 
        return entity.hasGameInputHumanSkillState && entity.gameInputHumanSkillState.IsEnd;
    }

    protected  override void Execute(List<InputEntity> entities)    
    {
        foreach (InputEntity inputEntity in entities)
        {
            int code = inputEntity.gameInputHumanSkillState.SkillCode;
            code = GetValidCode(code);
            contexts.service.gameServiceLogService.LogService.Log(code.ToString());
            inputEntity.ReplaceGameInputHumanSkillState(false, 0);
        }
    }

    private int GetValidCode(int code)
    {
        if(JudgeIsValidSkill(code))
        {
            return code;
        }
        else
        {
            return GetLongValidCode(code);
        }
    }

    /// <summary>
    /// 获取错误编码中最长的有效编码
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    private int GetLongValidCode(int code)
    {
        return 0;
    }

    private bool JudgeIsValidSkill(int code)
    {
        return GetValidData().Any(p => p.Code == code);
    }

    private List<ValidHumanSkill> GetValidData()
    {
        return contexts.game.gameModelHumanSkillConfig.ValidHumanSkills; 
    }
}
