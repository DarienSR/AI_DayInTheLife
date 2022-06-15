using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Environment;
namespace UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "NeedToWorkoutConsideration", menuName = "UtilityAI/Considerations/Workout Consideration")]
    public class NeedToWorkoutConsideration : Consideration
    {
        public override float ScoreConsideration(AgentController agent)
        {
            // takes agents stress level and combines it with the last time the agent excercised
            if(agent.environment.currentDay == 0) agent.environment.currentDay = 1; // fix error that was for some reason setting this value to 0, resulting in error by division
            if(agent.stats.lastExcercised == 0) agent.stats.lastExcercised = 1;  // fix error that was for some reason setting this value to 0, resulting in error by division
            float lastExcercised = Mathf.Clamp01((agent.environment.currentDay /  agent.stats.lastExcercised) - (agent.stats.lastExcercised / agent.environment.currentDay)); // normalize between 0 and 1
            score = (lastExcercised + agent.stats.stress) / 2; // add lastExcercised value to agent stress value then average it.
            return score;
        }   
    }
}