using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;
using Environment;
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
        public AgentMovement move { get; set; }
        public Action[] availableActions;


        void Start()
        {
            agent = GetComponent<Agent>();
            stats = GetComponent<AgentStats>();
            move = GetComponent<AgentMovement>();
            ui = GetComponent<UpdateAgentStatsUI>();
        }

        void Update()
        {
            if(agent.finishedDecidingAction)
            {
                agent.finishedDecidingAction = false;
                // update UI 
                ui.UpdateStatsText(stats.energy, stats.hunger);
                agent.chosenAction.PerformAction(this); // pass in this controller
            }
        }

        // Action has finished executing. Choose next action.
        public void OnFinishedAction()
        {
            agent.ChooseAction(availableActions);
        }

        public void DoEat(int time)
        {
            move.MoveTo(Waypoint.WaypointType.FRIDGE); // waypoint we want to move to
            StartCoroutine(EatCoroutine(time));
        }

        IEnumerator EatCoroutine(int time)
        {
            ui.UpdateBestAction("Travelling: " + agent.chosenAction.name);
            // wait until we have reached the hunting zone.
            Vector3 destination = move.environmentController.FindWaypoint(Waypoint.WaypointType.FRIDGE).GetPosition();
            while(agent.transform.position != destination)
            {
                yield return null;
            }

            ui.UpdateBestAction(agent.chosenAction.Name);

            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            stats.UpdateHunger(-100);
            stats.UpdateEnergy(-5);
            // decide next action
            OnFinishedAction();
        }

        public void DoWashroom(int time)
        {
            move.MoveTo(Waypoint.WaypointType.TOILET); // waypoint we want to move to
            StartCoroutine(WashroomCoroutine(time));
        }

        IEnumerator WashroomCoroutine(int time)
        {
            ui.UpdateBestAction("Travelling: " + agent.chosenAction.name);
            // wait until we have reached the hunting zone.
            Vector3 destination = move.environmentController.FindWaypoint(Waypoint.WaypointType.TOILET).GetPosition();
            while(agent.transform.position != destination)
            {
                yield return null;
            }
            ui.UpdateBestAction(agent.chosenAction.Name);

            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(3);
                counter--;
            }
            stats.UpdateBowels(-100);
            // decide next action
            DoWashHands(3);
        }


        public void DoWashHands(int time)
        {
            move.MoveTo(Waypoint.WaypointType.SINK); // waypoint we want to move to
            StartCoroutine(WashHandsCoroutine(time));
        }
        IEnumerator WashHandsCoroutine(int time)
        {
            ui.UpdateBestAction("Travelling: " + agent.chosenAction.name);
            // wait until we have reached the hunting zone.
            Vector3 destination = move.environmentController.FindWaypoint(Waypoint.WaypointType.SINK).GetPosition();
            while(agent.transform.position != destination)
            {
                yield return null;
            }
            ui.UpdateBestAction("Wash Hands");

            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            OnFinishedAction();
        }

        public void DoWork(int time)
        {
            move.MoveTo(Waypoint.WaypointType.WORK); // waypoint we want to move to
            StartCoroutine(WorkCoroutine(time));
        }
        IEnumerator WorkCoroutine(int time)
        {
            ui.UpdateBestAction("Travelling: " + agent.chosenAction.name);
            // wait until we have reached the hunting zone.
            Vector3 destination = move.environmentController.FindWaypoint(Waypoint.WaypointType.WORK).GetPosition();
            while(agent.transform.position != destination)
            {
                yield return null;
            }
            ui.UpdateBestAction(agent.chosenAction.Name);

            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            stats.UpdateEnergy(-30);
            stats.UpdateHunger(60);
            stats.UpdateStress(30);
            // decide next action
            OnFinishedAction();
        }
        
        public void DoWatchTV(int time)
        {
            move.MoveTo(Waypoint.WaypointType.COUCH_WATCHTV); // waypoint we want to move to
            StartCoroutine(WatchTVCoroutine(time));
        } 

        IEnumerator WatchTVCoroutine(int time)
        {
            ui.UpdateBestAction("Travelling: " + agent.chosenAction.name +".");
            // wait until we have reached the hunting zone.
            Vector3 destination = move.environmentController.FindWaypoint(Waypoint.WaypointType.COUCH_WATCHTV).GetPosition();
            while(agent.transform.position != destination)
            {
                yield return null;
            }
            ui.UpdateBestAction(agent.chosenAction.Name);

            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            stats.UpdateEnergy(-10);
            stats.UpdateHunger(5);
            stats.UpdateStress(-15);
            // decide next action
            OnFinishedAction();
        }


        public void DoRead(int time)
        {
            move.MoveTo(Waypoint.WaypointType.CHAIR); // waypoint we want to move to
            StartCoroutine(ReadCoroutine(time));
        }

        IEnumerator ReadCoroutine(int time)
        {
            ui.UpdateBestAction("Travelling: " + agent.chosenAction.name);
            // wait until we have reached the hunting zone.
            Vector3 destination = move.environmentController.FindWaypoint(Waypoint.WaypointType.CHAIR).GetPosition();
            while(agent.transform.position != destination)
            {
                yield return null;
            }
            ui.UpdateBestAction(agent.chosenAction.Name);

            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            // decide next action
            OnFinishedAction();
        }

    
        public void DoRelax(int time)
        {
            
        }

        public void DoSleep(int time)
        {
            move.MoveTo(Waypoint.WaypointType.BED); // waypoint we want to move to
            StartCoroutine(SleepCoroutine(time));
        }

        IEnumerator SleepCoroutine(int time)
        {
            ui.UpdateBestAction("Travelling: " + agent.chosenAction.name);
            // wait until we have reached the hunting zone.
            Vector3 destination = move.environmentController.FindWaypoint(Waypoint.WaypointType.BED).GetPosition();
            while(agent.transform.position != destination)
            {
                yield return null;
            }
            ui.UpdateBestAction(agent.chosenAction.Name);

            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            stats.UpdateEnergy(100);
            stats.UpdateHunger(30);
            OnFinishedAction();
        }
    }
}


// StartCoroutine(PerformCoroutine(action.actionElapsedTime))

// PerformCoroutine()
    // waits for action.ElapsedTime, then calls action.PerformAction()

// Goal of the above is cleann up the AgentController and contain action within action