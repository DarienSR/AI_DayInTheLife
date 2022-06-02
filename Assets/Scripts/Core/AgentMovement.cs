using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Environment;
namespace Core
{
    public class AgentMovement : MonoBehaviour
    {
        public GameObject environment;
        private MapGeneration _map;
        float speed = 1f;

        private Vector3 newPos;

        // Start is called before the first frame update
        void Start()
        {   
            _map = environment.GetComponent<MapGeneration>();
            // MoveTo(_map.map[25, 25].transform.position);
        }

        void Update()
        {
           transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * speed);
        }

        public void MoveTo(Vector3 newPosition)
        {
            newPos = newPosition;
        }
    }
}
