using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "Hunt", menuName = "UtilityAI/Actions/Hunt")]
    public class Hunt : Action
    {
        public Hunt()
        {
            Name = "Hunt";
        } 
        public override void PerformAction(AgentController agent)
        {
            agent.DoHunt(2);
        }
    }
}   