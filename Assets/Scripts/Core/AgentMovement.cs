using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UtilityAI;
using Environment;
/*  
    Controls the movement from agent to waypoints
*/

namespace Core
{
    public class AgentMovement : MonoBehaviour
    {
        public GameObject environment;
        float speed = 5f;
        private Agent agent;
        private Vector3 newPos;
        public EnvironmentController environmentController; // gives access to all the waypoints on the map

        void Start()
        {   
            environmentController = environment.GetComponent<EnvironmentController>();
            agent = GetComponent<Agent>();
        }

        // On each update we are moving to a new position. If we are already at that position, we do not move. 
        // If a new action is chosen that requires us to move, the newPos is set to that actions waypoint POS, 
        // and the agent begins to move towards it.
        void Update()
        {
           transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * speed);
        }

        // Function to select a waypoint given its type (i.e. Bed) and get the position. If there is no waypoint that matches
        // the passed in WaypointType, then we just set the newPosition to the agents current position (i.e. we do not move).
        public void MoveTo(Waypoint.WaypointType type)
        {
            Waypoint waypoint = environmentController.FindWaypoint(type);
            if(waypoint == null) 
            {
                Debug.Log("No waypoint found.");
                newPos = agent.transform.position; // don't move anywhere (give current location)
                return;
            }
            newPos = waypoint.GetPosition();
        }
    }
}
