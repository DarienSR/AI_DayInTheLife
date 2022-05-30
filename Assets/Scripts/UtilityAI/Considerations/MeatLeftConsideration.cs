using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.Considerations
{
    // How much meat does the agent have left in their storage.
    [CreateAssetMenu(fileName = "MeatLeftConsideration", menuName = "UtilityAI/Considerations/MeatLeft Consideration")]
    public class MeatLeftConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(AgentController agent)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(agent.stats.meatQuantity / 100f));
            return score;
        }
    }
}
