using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "WoodLeftConsideration", menuName = "UtilityAI/Considerations/Wood Left Consideration")]
    public class WoodLeftConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(AgentController agent)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(agent.stats.woodAvailable / 100f));
            return score;
        }   
    }
}