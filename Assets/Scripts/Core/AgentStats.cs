using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Holds all the agent stats and the methods to update them.
*/

namespace Core
{
    public class AgentStats : MonoBehaviour
    {
        [SerializeField]  private float _hunger;
        public float hunger
        {
            get {  return _hunger; }
            set 
            {
                _hunger = Mathf.Clamp(value, 0, 100); // restrict the value between 0 and 100
            }
        }

        [SerializeField] private float _money;
        public float money
        {
            get { return _money; }
            set
            {
                _money = value;
            }
        }

        [SerializeField] private float _sweat;
        public float sweat
        {
            get { return _sweat; }
            set 
            {
                _sweat = Mathf.Clamp(value, 0, 100); // restrict value between 0 and 100
            }
        }

        [SerializeField] private float _stress;
        public float stress
        {
            get { return _stress; }
            set 
            {
                _stress = Mathf.Clamp(value, 0, 100); // restrict value between 0 and 100
            }
        }

        // control agent sleeping
        [SerializeField] private float _tiredness;
        public float tiredness
        {
            get { return _tiredness; }
            set 
            {
                _tiredness = Mathf.Clamp(value, 0, 100); // restrict value between 0 and 100
            }
        }


        [SerializeField] private int _lastExcercised;
        public int lastExcercised = 1;

        // Control hunger increasing overtime
        [SerializeField] private float timeToDecreaseHunger = 5f; // how many seconds to wait to decrease hunger
        private float timeLeftHunger; // remaining time left until hunger should be decreased

        public void UpdateHungerOvertime()
        {
            if (timeLeftHunger > 0)
            {
                timeLeftHunger -= Time.deltaTime;
                return;
            }
            timeLeftHunger = timeToDecreaseHunger;
            hunger += 13;
        }


        [SerializeField] private float timeToIncreaseTiredness = 10f; // how many seconds to wait to decrease hunger
        private float timeLeftTiredness; // remaining time left until hunger should be decreased
        public void UpdateTirednessOvertime()
        {
            if (timeLeftTiredness > 0)
            {
                timeLeftTiredness -= Time.deltaTime;
                return;
            }
            timeLeftTiredness = timeToIncreaseTiredness;
            tiredness += Random.Range(20, 30); // add a random value between 20 and 30 every 5 seconds to determine how tired the agent is
        }

        void Start()
        {
            money = 100; // start off with $100
            // Randomize the starting values of the below stats
            stress = Random.Range(0, 100);
            sweat = Random.Range(0, 100);
            hunger = Random.Range(0, 100);
        }
    }
}
