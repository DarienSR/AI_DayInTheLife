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
            score = Mathf.Clamp01((Mathf.Pow(Mathf.Pow(agent.stats.money / 100f, 0.8f), -2)));
            return score;
        }   
    }
}
