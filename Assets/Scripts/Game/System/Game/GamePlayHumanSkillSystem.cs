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

            //skillCodeΪ0ʱ��������״̬
            //skillCode����0ʱ������������ִ�б���
            contexts.game.gamePlayer.PlayerAni.Attack(skillCode);
            

            if (skillCode > 0)
            {
                contexts.game.gamePlayer.PlayerBehaviour.Attack(skillCode);
                contexts.game.gamePlayer.PlayerAudio.Attack(skillCode);
            }
          
        }
    }
}
