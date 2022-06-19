using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UI;

/*
    The connection between the agent and the environment. References and holds information relating to waypoints and controls the weather.
*/

namespace Environment
{
    public class EnvironmentController : MonoBehaviour
    {
        public List<Waypoint> waypoints;
        [SerializeField] public ParticleSystem rain;
        private UpdateAgentStatsUI ui { get; set; } // allow us to update the agents UI, which shows us agent/environmental stats and current action
        AgentStats stats;
        public enum WeatherStates
        {
            Sunny,
            Rainy
        }

        public int dayLength = 24; 
        public int currentDay = 1; // every 24 seconds (value of dayLength), currentDay should be incremented. 
        public int daysTillRentDue = 4;
        public int rentDue = 6; // rent due every 4 days
        
        public int rentAmount = 300; // rent amount per 4 days
        public int timeOfDay = 1;

        private float[,] transitionState = {
            { 0.85f, 0.15f }, // State Sunny, 0.85% chance of staying in sunny state, 0.15% transitioning to Rainy
            { 0.7f, 0.3f } // State Rainy, 0.7% chance of staying in the rainy state, 0.3% transitioning to Rainy.
        };

        public WeatherStates currentWeather = WeatherStates.Sunny;

        // Start is called before the first frame update
        void Awake()
        {
            waypoints = new List<Waypoint>();
            ui = GameObject.Find("Agent").GetComponent<UpdateAgentStatsUI>(); // find the agent gameobject and then get the UI script attached to
            stats = GameObject.Find("Agent").GetComponent<AgentStats>(); // find the agent gameobject and then get the UI script attached to
            rain.Stop();
            ui.UpdateWeatherText(currentWeather.ToString());
        }

        public void AddWaypoint(Waypoint waypoint)
        {
            waypoints.Add(waypoint);
        }

        public Waypoint FindWaypoint(Waypoint.WaypointType type)
        {
            foreach(Waypoint waypoint in waypoints)
            {
                if(waypoint.waypointType == type)
                {
                    return waypoint;
                }
            }
            Debug.Log("No waypoint returned.");
            return null;
        }

        int randomizeWeatherInterval = 12; // amount of time between weather transitions 
        // Determine weather for the new day
        IEnumerator WeatherCycle(int time)
        {
            while (true)
            {
                yield return new WaitForSeconds(randomizeWeatherInterval);

                if(Random.Range(0f, 1f) > transitionState[(int)currentWeather, 0]) // transition
                {
                    currentWeather = currentWeather == WeatherStates.Sunny ? WeatherStates.Rainy : WeatherStates.Sunny;
                }
                if(currentWeather == WeatherStates.Rainy) 
                {
                    rain.Play();
                    ui.UpdateWeatherText("Raining");
                }
                else 
                {
                    rain.Stop();
                    ui.UpdateWeatherText("Sunny");
                }
            }
        }

        // Day Cycle
        IEnumerator DayCycle()
        {
            while(true)
            {
                yield return new WaitForSeconds(1);
                timeOfDay++; 
                if(timeOfDay == dayLength)
                {
                    // increment currentDay
                    currentDay += 1;
                    timeOfDay = 1; // reset timeOfDay
                    daysTillRentDue -= 1; // subtract 1 from days till rent has to be paid
                }
            }
        }

        IEnumerator RentCycle()
        {
            while(true)
            {
                yield return new WaitForSeconds(rentDue * dayLength);
                daysTillRentDue = 4; // reset days till rent is due
                stats.money -= rentAmount;
            }
        }


        private void Start()
        {
            StartCoroutine(DayCycle());
            StartCoroutine(WeatherCycle(dayLength));
            StartCoroutine(RentCycle());
        }
    }
}
