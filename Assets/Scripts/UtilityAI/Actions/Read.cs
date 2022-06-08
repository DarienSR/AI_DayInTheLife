using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "Read", menuName = "UtilityAI/Actions/Read")]
    public class Read : Action
    {
        public Read()
        {
            Name = "Read";
        }

        public override void PerformAction(AgentController agent)
        {
            agent.DoRead(2);
        }
    }
}   
