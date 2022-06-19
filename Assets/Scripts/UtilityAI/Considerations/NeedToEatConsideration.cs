using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "NeedToEatConsideration", menuName = "UtilityAI/Considerations/Eat Consideration")]
    public class NeedToEatConsideration : Consideration
    {
        public override float ScoreConsideration(AgentController agent)
        {
            score = agent.stats.hunger / 100;
            return score;
        }   
    }
}