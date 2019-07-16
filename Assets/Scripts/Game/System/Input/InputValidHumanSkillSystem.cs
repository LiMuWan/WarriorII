using Entitas;
using System.Collections.Generic;

/// <summary>
/// 有效技能相应系统  
/// </summary>
public class InputValidHumanSkillSystem:ReactiveSystem<InputEntity> 
{
    protected Contexts contexts;

    public   InputValidHumanSkillSystem(Contexts contexts): base(contexts.input)    
    {
        this.contexts = contexts;
    }

    protected  override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)     
    {
        return context.CreateCollector(InputMatcher.GameInputValidHumanSkill);
    }

    protected  override bool Filter(InputEntity entity)    
    {
        return entity.hasGameInputValidHumanSkill && 
            entity.gameInputValidHumanSkill.IsValid; 
    }

    protected  override void Execute(List<InputEntity> entities)    
    {
        //发出信号，当前播放技能，动画，声音，特效
        foreach (var entity in entities)
        {
            var skillCode = entity.gameInputValidHumanSkill.SkillCode;
            contexts.game.gamePlayer.PlayerAni.Attack(skillCode);
            entity.ReplaceGameInputValidHumanSkill(false, 0);
        }
    }
}
