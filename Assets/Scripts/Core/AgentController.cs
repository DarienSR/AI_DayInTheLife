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
        public EnvironmentController environment;

        void Start()
        {
            agent = GetComponent<Agent>();
            stats = GetComponent<AgentStats>();
            move = GetComponent<AgentMovement>();
            ui = GetComponent<UpdateAgentStatsUI>();
            environment = GameObject.Find("Environment").GetComponent<EnvironmentController>();
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

            // Overtime take away energy, increase hunger, and the need to use the washroom
            stats.UpdateHungerOvertime();
        }




        // Choose next action. This is called at the end of every action.
        public void OnFinishedAction()
        {
            agent.ChooseAction(availableActions);
        }


        public void DoWorkout(int time)
        {
            StartCoroutine(WorkoutCoroutine(time)); // Actually start the action
        }

        IEnumerator WorkoutCoroutine(int time)
        {
            Vector3 destination;
            if(environment.currentWeather == EnvironmentController.WeatherStates.Sunny)
            {
                move.MoveTo(Waypoint.WaypointType.JOG); // waypoint we want the agent to move to
                destination = GetWaypointDestination(Waypoint.WaypointType.JOG);
            }
            else
            {
                 move.MoveTo(Waypoint.WaypointType.YOGA); // waypoint we want the agent to move to
                destination = GetWaypointDestination(Waypoint.WaypointType.YOGA);
            }

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
            stats.sweat += 60;
            stats.stress -= 50;
            stats.hunger += 30;
            stats.lastExcercised = environment.currentDay;
            OnFinishedAction(); // decide next action
        }

        public void DoShower(int time)
        {
            move.MoveTo(Waypoint.WaypointType.SHOWER); // waypoint we want the agent to move to
            StartCoroutine(ShowerCoroutine(time)); // Actually start the action
        }

        IEnumerator ShowerCoroutine(int time)
        {
            Vector3 destination = GetWaypointDestination(Waypoint.WaypointType.SHOWER);
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
            stats.sweat -= 100;
            OnFinishedAction(); // decide next action
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
            stats.hunger -= 100;
            OnFinishedAction(); // decide next action
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
            stats.stress += 30;
            stats.money += 150;
            OnFinishedAction();  // decide next action
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
            stats.stress -= 20;
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
            stats.stress -= 90;
            stats.sweat += 75;
            stats.hunger += 60;

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

