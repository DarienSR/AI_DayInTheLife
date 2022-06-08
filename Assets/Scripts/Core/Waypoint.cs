using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace Environment
{
    public class Waypoint : MonoBehaviour
    {
        public enum WaypointType 
        {
            BED,
            CHAIR, // for reading
            TOILET,
            SINK,
            FRIDGE,
            COUCH_LAYDOWN,
            COUCH_WATCHTV,
            WORK
    
        }

        public WaypointType waypointType;
        public GameObject environment;
        private EnvironmentController environmentController;
        public int xPos { get; set; }
        public int zPos { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            environmentController = environment.GetComponent<EnvironmentController>();
            environmentController.AddWaypoint(this);
        }

        public Vector3 GetPosition()
        {
            return this.transform.position;
        }

        public void SetWaypointColor()
        {

        }
    }
}
