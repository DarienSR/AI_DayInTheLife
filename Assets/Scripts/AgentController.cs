using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Contains the Agent controls.
*/
namespace UtilityAI
{
    public class AgentController : MonoBehaviour
    {
        public Agent agent { get; set; }

        public Action[] availableActions;

        void Start()
        {
            agent = GetComponent<Agent>();
        }

        void Update()
        {
            if(agent.finishedDecidingAction)
            {
                agent.finishedDecidingAction = false;
                agent.chosenAction.PerformAction(this); // pass in this controller
            }
        }

        // Action has finished executing. Choose next action.
        public void OnFinishedAction()
        {
            agent.ChooseAction(availableActions);
        }
    }
}

