using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// ��Animator���ж��η�װ����չ����
    /// </summary>
    public static class AnimatorUtil
    {
        /// <summary>
        /// ��ȡ��ǰ�㼶������״̬
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
        /// ��ȡ��ǰAnimator��Ӧ�㼶��״̬��
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
        /// ��ȡ��״̬��������
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
        /// ͨ����״̬�����ƻ�ȡ��״̬��
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
                Debug.LogError("δ�ҵ�����Ϊ" + stateMachineName + "����״̬��");
            }
            return machine;
        }

        /// <summary>
        /// �Ƴ���ǰ�����еĹ���״̬
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
        /// �Ƴ�ָ��״̬�����й���״̬
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
