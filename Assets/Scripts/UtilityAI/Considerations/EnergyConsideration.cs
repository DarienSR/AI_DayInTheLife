using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "EnergyConsideration", menuName = "UtilityAI/Considerations/Energy Consideration")]
    public class EnergyConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(AgentController agent)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(agent.stats.energy / 100f));
            return score;
        }   
    }
}