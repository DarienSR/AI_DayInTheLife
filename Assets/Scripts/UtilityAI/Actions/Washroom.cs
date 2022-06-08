using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "Washroom", menuName = "UtilityAI/Actions/Washroom")]
    public class Washroom : Action
    {
        public Washroom()
        {
            Name = "Washroom";
        }

        public override void PerformAction(AgentController agent)
        {
            agent.DoWashroom(2);
        }
    }
}   

