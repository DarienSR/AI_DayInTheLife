using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "HungerConsideration", menuName = "UtilityAI/Considerations/Hunger Consideration")]
    public class HungerConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(AgentController agent)
        {
            // For hunger we want to consider:
            // Hunger - hunger levels 
            // Energy - Low energy eat to replenish energy
            // Stress - high stress will lead to stress eating (for further compelxity, this could be controled by a agent trait/characteristic)
            float stressLevel = (agent.stats.stress / 100f);
            // if our stress level is below 60, we will not be tempted by stress eating.
            if(stressLevel < 60) stressLevel = 0; 

            float tirednessLevel = (agent.stats.energy / 100f);
            // if our energy level is above 75, meaning we are kind of tired (100 being exhausted), we will put more value into wanting to eat
            if(tirednessLevel < 75) tirednessLevel = 0;

            score = Mathf.Clamp01(Mathf.Pow(((agent.stats.hunger / 100f) + (stressLevel / 5f) + (tirednessLevel / 10f)), 2));
            return score;
        }   
    }
}
