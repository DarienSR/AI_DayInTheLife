using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;
using Environment;
using UI;
/*
    Outlines the various actions and general agent movement.
*/
namespace Core
{
    public class AgentController : MonoBehaviour
    {
        public Agent agent { get; set; } // reference to the agent so we can access the functions to evaluate which actions we should take
        public AgentStats stats { get; set; } // information relating to the agents vitals/stats to give guidance on which action we should perform
        public UpdateAgentStatsUI ui { get; set; } // allow us to update the agents UI, which shows us agent/environmental stats and current action
        public AgentMovement move { get; set; }
        public Action[] availableActions; // list of actions available to choose from


        void Start()
        {
            agent = GetComponent<Agent>();
            stats = GetComponent<AgentStats>();
            move = GetComponent<AgentMovement>();
            ui = GetComponent<UpdateAgentStatsUI>();
        }


        void Update()
        {
            // check to see if we have just finished executing an action. If so, the action will set the finishedDecidingAction to 'true' and then calls the OnFinishedAction function
            //     which chooses the next action to execute. 
            if(agent.finishedDecidingAction)
            {
                agent.finishedDecidingAction = false; // flag so we can execute the chosen action 
                agent.chosenAction.PerformAction(this); // execute the chosen action
            }
            stats.UpdateHungerOvertime();
            stats.PayRent();
        }

        // Overtime take away energy, increase hunger, and the need to use the washroom


        // Choose next action. This is called at the end of every action.
        public void OnFinishedAction()
        {
            agent.ChooseAction(availableActions);
        }

        // The DoEat action object will call this function to execute itself.
        public void DoEat(int time)
        {
            move.MoveTo(Waypoint.WaypointType.FRIDGE); // waypoint we want the agent to move to
            StartCoroutine(EatCoroutine(time)); // Actually start the action
        }

        IEnumerator EatCoroutine(int time)
        {
            Vector3 destination = GetWaypointDestination(Waypoint.WaypointType.FRIDGE);
            while(agent.transform.position != destination)
            {
                yield return null;
            }

            // Once we have reached the waypoint, update the UI to show the currently selected action.
            ui.UpdateBestAction(agent.chosenAction.Name);
            // Counts down from the passed in time. Essentially controls how long the action takes.
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            // Update stats to reflect how the action influences agent/environment
            stats.UpdateHunger(-100); // take away all hunger
            stats.UpdateEnergy(-5);
            OnFinishedAction(); // decide next action
        }

        // The DoWashroom action object will call this function to execute itself.
        public void DoWashroom(int time)
        {
            move.MoveTo(Waypoint.WaypointType.TOILET); // waypoint we want to move to
            StartCoroutine(WashroomCoroutine(time));
        }

        IEnumerator WashroomCoroutine(int time)
        {
            Vector3 destination = GetWaypointDestination(Waypoint.WaypointType.TOILET);
            // Once we have reached the waypoint, update the UI to show the currently selected action.
            while(agent.transform.position != destination)
            {
                yield return null;
            }
            // Once we have reached the waypoint, update the UI to show the currently selected action.
            ui.UpdateBestAction(agent.chosenAction.Name);
            // Counts down from the passed in time. Essentially controls how long the action takes.
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(3);
                counter--;
            }
            // Update stats to reflect how the action influences agent/environment
            stats.UpdateBowels(-100);
            // go and wash your hands. This is a special case, we are forcing a specific action to get selected.
            // Another way to do this is to use "WashHands" as a normal action and just assign a high utility of washing your hands after going to the washroom.
            DoWashHands(3); 
        }

        public void DoWashHands(int time)
        {
            move.MoveTo(Waypoint.WaypointType.SINK); // waypoint we want to move to
            StartCoroutine(WashHandsCoroutine(time));
        }

        IEnumerator WashHandsCoroutine(int time)
        {
            Vector3 destination = GetWaypointDestination(Waypoint.WaypointType.SINK);
            while(agent.transform.position != destination)
            {
                yield return null;
            }
            ui.UpdateBestAction("Wash Hands");
            // Once we have reached the waypoint, update the UI to show the currently selected action.
            // This is a special action, that follows right after the "Washroom" action.
            // Counts down from the passed in time. Essentially controls how long the action takes.
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1.5f);
                counter--;
            }
            OnFinishedAction(); // decide a new action
        }

        public void DoWork(int time)
        {
            move.MoveTo(Waypoint.WaypointType.WORK); // waypoint we want to move to
            StartCoroutine(WorkCoroutine(time));
        }
        IEnumerator WorkCoroutine(int time)
        {
            Vector3 destination = GetWaypointDestination(Waypoint.WaypointType.WORK);
            while(agent.transform.position != destination)
            {
                yield return null;
            }
            // Once we have reached the waypoint, update the UI to show the currently selected action.
            ui.UpdateBestAction(agent.chosenAction.Name);
            // Counts down from the passed in time. Essentially controls how long the action takes.
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            // Update stats to reflect how the action influences agent/environment
            stats.UpdateEnergy(30);
            stats.UpdateHunger(20);
            stats.UpdateStress(10);
            stats.UpdateMoney(30);
            OnFinishedAction();  // decide next action
        }
        
        public void DoWatchTV(int time)
        {
            move.MoveTo(Waypoint.WaypointType.COUCH_WATCHTV); // waypoint we want to move to
            StartCoroutine(WatchTVCoroutine(time));
        } 

        IEnumerator WatchTVCoroutine(int time)
        {
            Vector3 destination = GetWaypointDestination(Waypoint.WaypointType.COUCH_WATCHTV);
            while(agent.transform.position != destination)
            {
                yield return null;
            }

            // Once we have reached the waypoint, update the UI to show the currently selected action.
            ui.UpdateBestAction(agent.chosenAction.Name);
            // Counts down from the passed in time. Essentially controls how long the action takes.

            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            // Update stats to reflect how the action influences agent/environment
            stats.UpdateEnergy(10);
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
            Vector3 destination = GetWaypointDestination(Waypoint.WaypointType.CHAIR);
            while(agent.transform.position != destination)
            {
                yield return null;
            }
            // Once we have reached the waypoint, update the UI to show the currently selected action.
            ui.UpdateBestAction(agent.chosenAction.Name);
            // Counts down from the passed in time. Essentially controls how long the action takes.
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            stats.UpdateEnergy(5);
            stats.UpdateHunger(5);
            stats.UpdateStress(-20);
            OnFinishedAction();             // decide next action
        }

        public void DoSleep(int time)
        {
            move.MoveTo(Waypoint.WaypointType.BED); // waypoint we want to move to
            StartCoroutine(SleepCoroutine(time));
        }

        IEnumerator SleepCoroutine(int time)
        {
            Vector3 destination = GetWaypointDestination(Waypoint.WaypointType.BED);
            while(agent.transform.position != destination)
            {
                yield return null;
            }
            // Once we have reached the waypoint, update the UI to show the currently selected action.
            ui.UpdateBestAction(agent.chosenAction.Name);
            // Counts down from the passed in time. Essentially controls how long the action takes.

            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            // Update stats to reflect how the action influences agent/environment
            stats.UpdateEnergy(100);
            stats.UpdateHunger(30);
            OnFinishedAction();
        }

        // Fetch the action destination (each action has a waypoint, get get the waypoints' POS) 
        // Update UI to travelling and wait until we have reached the desired waypoint.
        private Vector3 GetWaypointDestination(Waypoint.WaypointType waypoint)
        {
            ui.UpdateBestAction("Travelling");
            return move.environmentController.FindWaypoint(waypoint).GetPosition();
        }
    }
}

