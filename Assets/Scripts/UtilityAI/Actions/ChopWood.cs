using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "ChopWood", menuName = "UtilityAI/Actions/Chop Wood")]
    public class ChopWood : Action
    {   
        public ChopWood()
        {
            Name = "Chopping Wood";
        }

        public override void PerformAction(AgentController agent)
        {
            agent.DoChopWood(3);
        }
    }
}   
