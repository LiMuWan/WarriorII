using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// 对Animator进行二次封装的扩展方法
    /// </summary>
    public static class AnimatorUtil
    {
        /// <summary>
        /// 获取当前层级的所有状态
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static AnimatorState[] GetAnimatorState(this Animator ani,int layer)
        {
            var machine = ani.GetAnimatorStateMachine(layer);
            return machine.states.Select(u => u.state).ToArray();
        }

        /// <summary>
        /// 获取当前Animator对应层级的状态机
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static AnimatorStateMachine GetAnimatorStateMachine(this Animator ani,int layer)
        {
            AnimatorController aniController = ani.runtimeAnimatorController as AnimatorController;
            return aniController.layers[layer].stateMachine;
        }

        /// <summary>
        /// 获取子状态机的数组
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="baseLayer"></param>
        /// <returns></returns>
        public static AnimatorStateMachine[] GetSubStateMachine(this Animator ani,int baseLayer)
        {
            var baseMachine = ani.GetAnimatorStateMachine(baseLayer);
            return baseMachine.stateMachines.Select(u => u.stateMachine).ToArray();
        }

        /// <summary>
        /// 通过子状态机名称获取子状态机
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="baseLayer"></param>
        /// <param name="stateMachineName"></param>
        /// <returns></returns>
        public static AnimatorStateMachine GetSubStateMachine(this Animator ani,int baseLayer,string stateMachineName)
        {
            var machines = ani.GetSubStateMachine(baseLayer);
            AnimatorStateMachine machine = machines.FirstOrDefault(u => u.name == stateMachineName);
            if(machine == null)
            {
                Debug.LogError("未找到名称为" + stateMachineName + "的子状态机");
            }
            return machine;
        }

        /// <summary>
        /// 移除当前层所有的过渡状态
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="layer"></param>
        public static void RemoveAllTrasition(this Animator ani,int layer)
        {
            var states = ani.GetAnimatorState(layer);
            foreach (AnimatorState state in states)
            {
                state.RemoveStateAllTrasition();
            }
        }

        /// <summary>
        /// 移除指定状态的所有过渡状态
        /// </summary>
        /// <param name="state"></param>
        public static void RemoveStateAllTrasition(this AnimatorState state)
        {
            foreach (AnimatorStateTransition transition in state.transitions)
            {
                state.RemoveTransition(transition);
            }
        }
    }
}
