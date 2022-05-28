using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "Eat", menuName = "UtilityAI/Actions/Eat")]
    public class Eat : Action
    {
        public override void PerformAction(AgentController agent)
        {
            Debug.Log("Eating");
            // Logic associated with eating
                // removing food from storage
                // adding food levels to energy and hunger
            agent.OnFinishedAction();
        }
    }
}   
