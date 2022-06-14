using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UI;
namespace Environment
{
    public class EnvironmentController : MonoBehaviour
    {
        public List<Waypoint> waypoints;
        [SerializeField] public ParticleSystem rain;
        private UpdateAgentStatsUI ui { get; set; } // allow us to update the agents UI, which shows us agent/environmental stats and current action
        private enum WeatherStates
        {
            Sunny,
            Rainy
        }

        private float[,] transitionState = {
            { 0.85f, 0.15f }, // State Sunny, 0.85% chance of staying in sunny state, 0.15% transitioning to Rainy
            { 0.7f, 0.3f } // State Rainy, 0.7% chance of staying in the rainy state, 0.3% transitioning to Rainy.
        };

        private WeatherStates currentWeather = WeatherStates.Sunny;

        private int currentState = 0; // current state is 0.

        int dayLength = 4;
        // Start is called before the first frame update
        void Awake()
        {
            waypoints = new List<Waypoint>();
            ui = GameObject.Find("Agent").GetComponent<UpdateAgentStatsUI>(); // find the agent gameobject and then get the UI script attached to
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

        private void Start()
        {
            StartCoroutine(DayCycle(dayLength));
        }

        // Determine weather for the new day
        IEnumerator DayCycle(int time)
        {
            while (true)
            {
                yield return new WaitForSeconds(dayLength);

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

    }
}
