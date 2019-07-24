using Entitas;
using System.Collections.Generic;

public class GameValidHumanSkillSystem:ReactiveSystem<GameEntity> 
{
    protected Contexts contexts;

    public   GameValidHumanSkillSystem(Contexts contexts): base(contexts.game)    
    {
        this.contexts = contexts;
    }

    protected  override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)     
    {
        return context.CreateCollector(GameMatcher.GameValidHumanSkill);
    }

    protected  override bool Filter(GameEntity entity)    
    {
        return entity.hasGameValidHumanSkill;
    }

    protected  override void Execute(List<GameEntity> entities)    
    {
        //�����źţ���ǰ���ż��ܣ���������������Ч
        foreach (var entity in entities)
        {
            var skillCode = entity.gameValidHumanSkill.SkillCode;
            contexts.game.gamePlayer.PlayerAni.Attack(skillCode); 
        }
    }
}
