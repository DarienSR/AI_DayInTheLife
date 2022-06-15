using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "ReadConsideration", menuName = "UtilityAI/Considerations/Read Consideration")]
    public class ReadConsideration : Consideration
    {
        public override float ScoreConsideration(AgentController agent)
        {
            score = 0.2f; // idle action. Default is 20.
            return score;
        }   
    }
}
