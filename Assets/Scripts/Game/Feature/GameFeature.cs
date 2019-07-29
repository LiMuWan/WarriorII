using UnityEngine;

namespace Game
{
    public class GameFeature : Feature  
    {
       public GameFeature(Contexts contexts)
        {
            InitializeFun(contexts);
            ExecuteFun(contexts);
            CleanupFun(contexts);
            TearDownFun(contexts);
            ReactiveSystemFun(contexts);
        }

        private void InitializeFun(Contexts contexts)
        {
            Add(new GameHumanAniEventSystem(contexts)); 
        }

        private void ExecuteFun(Contexts contexts)
        {
        }

        private void CleanupFun(Contexts contexts)
        {
        }

        private void TearDownFun(Contexts contexts)
        {
        } 

        private void ReactiveSystemFun(Contexts contexts)
        {
            Add(new GameValidHumanSkillSystem(contexts)); 
            Add(new GameStartSystem(contexts));
            Add(new GamePauseSystem(contexts));
            Add(new GameEndSystem(contexts));
            BehaviourSystem(contexts);
        }

        private void BehaviourSystem(Contexts contexts)
        {
            Add(new GameHumanIdleEnterStateSystem(contexts));
            Add(new GameHumanWalkEnterStateSystem(contexts));
            Add(new GameHumanAttackEnterStateSystem(contexts));

            Add(new GameHumanIdleUpdateStateSystem(contexts)); 
        }
    }
}
