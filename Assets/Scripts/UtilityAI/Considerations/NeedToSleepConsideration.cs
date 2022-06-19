using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "NeedToSleepConsideration", menuName = "UtilityAI/Considerations/Sleep Consideration")]
    public class NeedToSleepConsideration : Consideration
    {
        public override float ScoreConsideration(AgentController agent)
        {
            score = agent.stats.tiredness / 100f;
            return score;
        }   
    }
}
