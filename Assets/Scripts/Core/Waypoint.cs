using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Waypoint : MonoBehaviour
    {
        public enum WaypointType 
        {
            WATER,
            HUNTING,
            TOWN,
            TREE
        }

        public WaypointType waypointType;

        public int xPos { get; set; }
        public int zPos { get; set; }


        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void SetPosition()
        {
            this.transform.position = new Vector3(xPos, 5f, zPos);
        }

        public (int, int) GetPosition()
        {
            return (xPos, zPos);
        }
    }
}
