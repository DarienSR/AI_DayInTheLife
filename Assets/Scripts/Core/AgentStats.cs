using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class AgentStats : MonoBehaviour
    {
        [SerializeField]  private int _meatAvailable; 
        public int meatQuantity
        {
            get { return _meatAvailable; }
            set 
            {
                _meatAvailable = value;
            }
        }

        [SerializeField] private float timeToDecreaseHunger = 5f; // every x seconds, decrease hunger
        private float timeLeftHunger; // keep track of time to know when to decrease hunger
        [SerializeField]  private int _hunger;
        public int hunger
        {
            get {  return _hunger; }
            set 
            {
                _hunger = Mathf.Clamp(value, 0, 100);
            }
        }

        [SerializeField] private int _woodAvailable;
        public int woodAvailable
        {
            get {  return _hunger; }
            set 
            {
                _woodAvailable = value;
            }
        }

        [SerializeField] private int _energy;
        public int energy
        {
            get {  return _hunger; }
            set 
            {
                _energy = value;
            }
        }

        [SerializeField] private int _temperature;
        public int temperature
        {
            get {  return _temperature; }
            set 
            {
                _temperature = value;
            }
        }

        // Initialize stats to starting values
        void Start()
        {
            meatQuantity = Random.Range(0, 10);
            hunger = Random.Range(0, 100);
            energy = Random.Range(0, 100);
            woodAvailable = Random.Range(0, 10);
        }

        // Meat Quantity modified when hunting (increase) or eating (decreasing)
        public void UpdateMeatQuantity(int quantity)
        {
            if(meatQuantity + quantity <= 0) return;
            meatQuantity += quantity;
        }

        // Direct function to update hunger an action is carried out (i.e. eating, physical exertion, etc)
        public void UpdateHunger(int level)
        {
            hunger += level; // to do, energy excertion should impact how hungry you get. ex. hunting will increase hunger levels compared to reading
        }

        public void UpdateEnergy(int energyLevels)
        {
            if(energy + energyLevels <= 0)
            {
                energy = 0;
                return;
            }
            energy += energyLevels;
        }

        public void UpdateTemperature(int temp)
        {
            temperature += temp;
        }

        public void UpdateWoodQuantity(int amount)
        {
            woodAvailable += amount;
        }
    }
}
