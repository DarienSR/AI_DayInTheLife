using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "Workout", menuName = "UtilityAI/Actions/Workout")]
    public class Workout : Action
    {
        public Workout()
        {
            Name = "Workout";
        }

        public override void PerformAction(AgentController agent)
        {
            agent.DoWorkout(2);
        }
    }
}   
