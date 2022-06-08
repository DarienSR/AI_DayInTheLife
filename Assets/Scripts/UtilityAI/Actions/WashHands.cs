using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "WashHands", menuName = "UtilityAI/Actions/WashHands")]
    public class WashHands : Action
    {
        public WashHands()
        {
            Name = "WashHands";
        }

        public override void PerformAction(AgentController agent)
        {
            agent.DoWashHands(2);
        }
    }
}   
