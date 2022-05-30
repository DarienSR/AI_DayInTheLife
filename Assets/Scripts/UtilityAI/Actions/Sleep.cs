using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "Sleep", menuName = "UtilityAI/Actions/Sleep")]
    public class Sleep : Action
    {   
        public Sleep()
        {
            Name = "Sleeping";
        }

        public override void PerformAction(AgentController agent)
        {
            agent.DoSleep(3);
        }
    }
}   

