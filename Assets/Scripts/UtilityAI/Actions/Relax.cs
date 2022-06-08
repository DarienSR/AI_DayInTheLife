using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "Relax", menuName = "UtilityAI/Actions/Relax")]
    public class Relax : Action
    {
        public Relax()
        {
            Name = "Relax";
        }

        public override void PerformAction(AgentController agent)
        {
            agent.DoRelax(2);
        }
    }
}   
