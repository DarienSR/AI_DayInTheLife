using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace Environment
{
    public class EnvironmentController : MonoBehaviour
    {
        public List<Waypoint> waypoints;

        // Start is called before the first frame update
        void Awake()
        {
            waypoints = new List<Waypoint>();
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
    }
}
