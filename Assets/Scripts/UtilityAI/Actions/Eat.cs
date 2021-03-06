using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "Eat", menuName = "UtilityAI/Actions/Eat")]
    public class Eat : Action
    {
        public Eat()
        {
            Name = "Eat";
        }

        public override void PerformAction(AgentController agent)
        {
            agent.DoEat(2);
        }
    }
}   
