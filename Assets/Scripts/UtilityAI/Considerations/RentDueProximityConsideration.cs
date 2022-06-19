using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "RentDueProximityConsideration", menuName = "UtilityAI/Considerations/Rent Due Proximity Consideration")]
    public class RentDueProximityConsideration : Consideration
    {
        public override float ScoreConsideration(AgentController agent)
        {
            score = 1 - (agent.environment.daysTillRentDue / agent.environment.rentDue);
            return score;
        }   
    }
}

