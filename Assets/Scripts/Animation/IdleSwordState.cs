using Module.Timer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSwordState : StateMachineBehaviour
{
    private ITimeManager timeManager;
    private ITimer timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Init();
        timer = timeManager.CreateTimer("IdleSwordState", 1, false);
        timer.AddCompleteListener(() => { animator.SetBool(Const.ConstValue.IDLE_SWORD_PARA_NAME, false); });
    }

    private void Init()
    {
        if(timeManager == null)
        {
            timeManager = new TimerManager();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer.Stop(false);
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
