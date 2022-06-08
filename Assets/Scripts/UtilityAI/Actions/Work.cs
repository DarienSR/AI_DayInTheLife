using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "Work", menuName = "UtilityAI/Actions/Work")]
    public class Work : Action
    {
        public Work()
        {
            Name = "Work";
        }

        public override void PerformAction(AgentController agent)
        {
            agent.DoWork(2);
        }
    }
}   
