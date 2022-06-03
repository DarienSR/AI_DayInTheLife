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
        void Start()
        {
            waypoints = new List<Waypoint>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void AddWaypoint(Waypoint waypoint, Waypoint.WaypointType type, (int, int) pos)
        {
            waypoint.xPos = pos.Item1;
            waypoint.zPos = pos.Item2;
            waypoint.SetPosition();
            waypoint.waypointType = type;

            waypoints.Add(waypoint);
        }
    }
}
