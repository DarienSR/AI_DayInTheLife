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
            score = Mathf.Clamp01(Mathf.Log(agent.stats.bowels / 100f, 2) + 1);
            return score;
        }   
    }
}

