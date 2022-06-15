using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "Shower", menuName = "UtilityAI/Actions/Shower")]
    public class Shower : Action
    {
        public Shower()
        {
            Name = "Shower";
        }

        public override void PerformAction(AgentController agent)
        {
            agent.DoShower(2);
        }
    }
}   

