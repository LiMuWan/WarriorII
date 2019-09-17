using UnityEngine;

namespace GOAP
{
    public interface ITrigger
    {
       bool IsTrigger { get; set; }
       void FrameFun();
    }

    public abstract class TriggerBase : ITrigger
    {
        public bool IsTrigger { get; set; }

        public void FrameFun()
        {
            
        }
    }
}
