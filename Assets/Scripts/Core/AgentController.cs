using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;
using UI;
/*
    Contains the Agent controls.
*/
namespace Core
{
    public class AgentController : MonoBehaviour
    {
        public Agent agent { get; set; }
        public AgentStats stats { get; set; }
        public UpdateAgentStatsUI ui { get; set; }
        public Action[] availableActions;

        void Start()
        {
            agent = GetComponent<Agent>();
            stats = GetComponent<AgentStats>();
            ui = GetComponent<UpdateAgentStatsUI>();
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
            ui.UpdateStatsText(stats.energy, stats.hunger);
            ui.UpdateInventoryText(stats.meatQuantity, stats.woodAvailable);
            ui.UpdateBestAction(agent.chosenAction.Name);
            agent.ChooseAction(availableActions);
        }

        public void DoEat(int time)
        {
            StartCoroutine(EatCoroutine(time));
        }

        IEnumerator EatCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log("I am eating.");
            stats.UpdateMeatQuantity(-3);
            stats.UpdateHunger(-100);
            stats.UpdateEnergy(5);
            // decide next action
            OnFinishedAction();
        }

        public void DoHunt(int time)
        {
            StartCoroutine(HuntCoroutine(time));
        }

        IEnumerator HuntCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log("I am hunting.");
            stats.UpdateMeatQuantity(10);
            stats.UpdateHunger(50);
            stats.UpdateEnergy(-60);
            // decide next action
            OnFinishedAction();
        }

        public void DoChopWood(int time)
        {
            StartCoroutine(ChopWoodCoroutine(time));
        }

        IEnumerator ChopWoodCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log("I am chopping wood");
            stats.UpdateEnergy(-30);
            stats.UpdateHunger(30);
            stats.UpdateWoodQuantity(10);
            OnFinishedAction();
        }

        public void DoSleep(int time)
        {
            StartCoroutine(SleepCoroutine(time));
        }

        IEnumerator SleepCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log("I am sleeping.");
            stats.UpdateEnergy(100);
            stats.UpdateHunger(30);
            OnFinishedAction();
        }
    }
}


