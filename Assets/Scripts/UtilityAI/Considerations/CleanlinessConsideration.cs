using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "CleanlinessConsideration", menuName = "UtilityAI/Considerations/Cleanliness Consideration")]
    public class CleanlinessConsideration : Consideration
    {
        public override float ScoreConsideration(AgentController agent)
        {
            score = agent.stats.sweat / 100;
            return score;
        }   
    }
}
