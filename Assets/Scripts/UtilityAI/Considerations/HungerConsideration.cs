using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "HungerConsideration", menuName = "UtilityAI/Considerations/Hunger Consideration")]
    public class HungerConsideration : Consideration
    {
        public override float ScoreConsideration(AgentController agent)
        {
            score = 0.6f;
            return score;
        }   
    }
}
