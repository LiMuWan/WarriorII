using UnityEditor.Animations;
using UnityEngine;

namespace Game
{
    public class CustomAniEventManager
    {
        public CustomAniEventManager(Animator animator)
        {
            AnimatorController aniController = animator.runtimeAnimatorController as AnimatorController;
            AnimatorStateMachine aniMachine = aniController.layers[0].stateMachine;

            foreach (ChildAnimatorState state in aniMachine.states)
            {
                Debug.Log(state.state.name);
            }
        }
    }
}
