using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "Hunt", menuName = "UtilityAI/Actions/Hunt")]
    public class Hunt : Action
    {
        public override void PerformAction(AgentController agent)
        {
            Debug.Log("Hunting");
            // Logic associated with eating
                // removing food from storage
                // adding food levels to energy and hunger
            agent.OnFinishedAction();
        }
    }
}   