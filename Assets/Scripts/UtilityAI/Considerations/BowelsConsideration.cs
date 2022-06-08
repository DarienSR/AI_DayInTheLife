using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "BowelsConsideration", menuName = "UtilityAI/Considerations/Bowels Consideration")]
    public class BowelsConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(AgentController agent)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(agent.stats.bowels / 100f));
            return score;
        }   
    }
}

