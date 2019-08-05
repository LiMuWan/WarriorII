using Entitas;
using System.Collections.Generic;

/// <summary>
/// 人物技能响应系统，只接收有效的技能编码
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
        //发出信号，当前播放技能，动画，声音，特效
        foreach (var entity in entities)
        {
            var skillCode = entity.gamePlayHumanSkill.SkillCode;

            //skillCode为0时代表重置状态
            //skillCode大于0时，才是真正的执行编码
            contexts.game.gamePlayer.PlayerAni.Attack(skillCode);
            

            if (skillCode > 0)
            {
                contexts.game.gamePlayer.PlayerBehaviour.Attack(skillCode);
                contexts.game.gamePlayer.PlayerAudio.Attack(skillCode);
            }
          
        }
    }
}
