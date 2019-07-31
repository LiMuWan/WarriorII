using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAniState : StateMachineBehaviour
{
    int code = -1;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(code < 0)
        {
            try
            {
                string codeStr = name.Remove(name.Length - 7, 7);
                code = int.Parse(codeStr);
            }
            catch (System.Exception)
            {
                Debug.LogError("技能编码转换失败");
                code = 0;
            }
        }
        Contexts.sharedInstance.game.ReplaceGameStartHumanSkill(code);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Contexts.sharedInstance.game.ReplaceGameEndHumanSkill(code);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
