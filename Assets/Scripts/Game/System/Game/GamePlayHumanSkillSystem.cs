using Entitas;
using System.Collections.Generic;

/// <summary>
/// ���＼����Ӧϵͳ��ֻ������Ч�ļ��ܱ���
/// </summary>
public class GamePlayHumanSkillSystem:ReactiveSystem<GameEntity> 
{
    protected Contexts contexts;

    public   GamePlayHumanSkillSystem(Contexts contexts): base(contexts.game)    
    {
        this.contexts = contexts;
    }

    protected  override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)     
    {
        return context.CreateCollector(GameMatcher.GamePlayHumanSkill);
    }

    protected  override bool Filter(GameEntity entity)    
    {
        return entity.hasGamePlayHumanSkill;
    }

    protected  override void Execute(List<GameEntity> entities)    
    {
        //�����źţ���ǰ���ż��ܣ���������������Ч
        foreach (var entity in entities)
        {
            var skillCode = entity.gamePlayHumanSkill.SkillCode;
            if (skillCode > 0)
            {
                contexts.game.gamePlayer.PlayerAni.Attack(skillCode);
                contexts.game.gamePlayer.PlayerBehaviour.Attack(skillCode);
            }
            else
            {
                contexts.game.gamePlayer.PlayerAni.Attack(0);
            }
        }
    }
}
