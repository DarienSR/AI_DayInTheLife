using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "AmountOfRentNeededConsideration", menuName = "UtilityAI/Considerations/Rent Needed Consideration")]
    public class AmountOfRentNeededConsideration : Consideration
    {
        public override float ScoreConsideration(AgentController agent)
        {
            score = Mathf.Clamp01(1 - (agent.stats.money / agent.environment.rentAmount));
            return score;
        }   
    }
}

