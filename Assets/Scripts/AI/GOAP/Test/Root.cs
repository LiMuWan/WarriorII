using GOAP;
using UnityEngine;

namespace GOAPTest
{
    public class Root:MonoBehaviour     
    {

        private IAgent<ActionEnum, GoalEnum> _agent;
        public IAgent<ActionEnum,GoalEnum> Agent {
            get
            {
                return _agent;
            }
            private set {  }
        }
        private  void Start()         
        {
            _agent = new CustomAgent();
        }

        private void FixedUpdate()
        {
            _agent.FrameFun();
        }
    }
}
