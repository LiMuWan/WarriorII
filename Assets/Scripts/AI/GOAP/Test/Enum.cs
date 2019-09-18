using UnityEngine;

namespace GOAPTest
{
   public enum ActionEnum
   {
        IDLE,
        ALERT,
        MOVE,
        ATTACK,
        INJURE,
        ATTACK_IDLE
   }

    public enum GoalEnum
    {
        ATTACK,
        ALERT,
        ATTACK_IDLE,
        INJURE
    }

    public enum KeyNameEnum
    {
        IDLE,
        ALERT,
        MOVE,
        ATTACK,
        INJURE,
        ATTACK_IDLE,
        FIND_ENEMY,
        NEAR_ENEMY,
        KILLED_ENEMY
    }
}
