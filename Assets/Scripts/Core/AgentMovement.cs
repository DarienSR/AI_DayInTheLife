using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UtilityAI;
using Environment;
namespace Core
{
    public class AgentMovement : MonoBehaviour
    {
        public GameObject environment;
        float speed = 2f;
        private Agent agent;
        private Vector3 newPos;
        public EnvironmentController environmentController;

        // Start is called before the first frame update
        void Start()
        {   
            environmentController = environment.GetComponent<EnvironmentController>();
            agent = GetComponent<Agent>();
        }

        void Update()
        {
           transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * speed);
        }

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
