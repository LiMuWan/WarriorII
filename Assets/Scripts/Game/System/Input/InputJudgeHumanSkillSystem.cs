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
        return entity.gameInputButton.InputButton == Game.InputButton.ATTACK_X
            || entity.gameInputButton.InputButton == Game.InputButton.ATTACK_O;
    }

    protected  override void Execute(List<InputEntity> entities)    
    {
      
    }
}
