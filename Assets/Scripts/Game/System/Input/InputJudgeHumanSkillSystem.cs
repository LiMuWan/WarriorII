using Entitas;
using Game;
using Game.Service;
using System.Collections.Generic;

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
        return context.CreateCollector(InputMatcher.GameInputButton);
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
        }
    }

    private void GetValidData()
    {

    }
}
