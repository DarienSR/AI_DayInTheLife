using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "MeatLeftConsideration", menuName = "UtilityAI/Considerations/MeatLeft Consideration")]
    public class MeatLeftConsideration : Consideration
    {
        public override float ScoreConsideration(AgentController agent)
        {
            score = 0.3f;
            return score;
        }
    }
}
