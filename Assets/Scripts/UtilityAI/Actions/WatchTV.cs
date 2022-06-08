using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace UtilityAI.actions
{
    [CreateAssetMenu(fileName = "WatchTV", menuName = "UtilityAI/Actions/WatchTV")]
    public class WatchTV : Action
    {
        public WatchTV()
        {
            Name = "WatchTV";
        }

        public override void PerformAction(AgentController agent)
        {
            agent.DoWatchTV(2);
        }
    }
}   
