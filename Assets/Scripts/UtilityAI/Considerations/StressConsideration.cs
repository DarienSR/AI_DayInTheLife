using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "StressConsideration", menuName = "UtilityAI/Considerations/Stress Consideration")]
    public class StressConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(AgentController agent)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(agent.stats.stress / 100f));
            return score;
        }   
    }
}