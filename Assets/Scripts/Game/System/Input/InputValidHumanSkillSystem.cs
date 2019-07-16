using Entitas;
using System.Collections.Generic;

/// <summary>
/// ��Ч������Ӧϵͳ  
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
        //�����źţ���ǰ���ż��ܣ���������������Ч
        foreach (var entity in entities)
        {
            var skillCode = entity.gameInputValidHumanSkill.SkillCode;
            contexts.game.gamePlayer.PlayerAni.Attack(skillCode);
            entity.ReplaceGameInputValidHumanSkill(false, 0);
        }
    }
}
