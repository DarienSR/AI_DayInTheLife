using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
/* 

    This file contains all the decision logic for choosing and scoring actions.

*/
namespace UtilityAI
{
    public class Agent : MonoBehaviour
    {
        public bool finishedDecidingAction { get; set; } // when set to true it indicates an action has been chosen, will allow us to restart the process for choosing another action.
        public Action chosenAction { get; set; } // action with the highest utility and is currently being carried out
        private AgentController agentController; // holds all the agentController information, like movement, stats, etc.

        // Start is called before the first frame update
        void Start()
        {
            agentController = GetComponent<AgentController>();
        }

        // Update is called once per frame
        void Update()
        {
            if(chosenAction is null) ChooseAction(agentController.availableActions); // begins process of choosing an action
        }

        // Iterate through all the available actions and return the action with the highest utility 
        public void ChooseAction(Action[] actions)
        {
            float score = 0f;
            int actionIndex = 0;
            for(int i = 0; i < actions.Length; i++)
            {
                if(ScoreAction(actions[i]) > score) // if score of action is larger than the previous highest action score, replace it and save the index.
                {
                    actionIndex = i;
                    score = actions[i].score;
                }
            }
            // set chosen action
            finishedDecidingAction = true;
            chosenAction = actions[actionIndex]; 
            // TO DO: UPDATE AGENT UI PANEL TO INCLUDE CHOSEN ACTION
        }

        // Iterate through all the actions consideration and score them. Average them together to get the overall action score, which is returned to be compared
        // to all the other actions.
        public float ScoreAction(Action action)
        {
            float score = 1f;
            for(int i = 0; i < action.considerations.Length; i++)
            {
                score *= action.considerations[i].ScoreConsideration(agentController); // get the consideration score and multiply it to the overall score.
                if(score == 0) 
                {
                    action.score = 0;
                    return action.score; // action is no longer considered
                }
            }
            // average the overall score (normalizes actions despite having different number of considerations)
            // TO DO: Explain the below process
            float originalScore = score; // probably can just use score variable
            float modFactor = 1 - (1 / action.considerations.Length);
            float makeUpValue = (1 - originalScore) * modFactor;
            action.score = originalScore +  (makeUpValue * originalScore);
            return action.score;
        }
    }
}

