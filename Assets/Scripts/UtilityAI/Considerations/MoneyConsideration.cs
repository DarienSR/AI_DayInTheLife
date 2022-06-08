using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "MoneyConsideration", menuName = "UtilityAI/Considerations/Money Consideration")]
    public class MoneyConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(AgentController agent)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(agent.stats.money / 100f));
            return score;
        }   
    }
}
