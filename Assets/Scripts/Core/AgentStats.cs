using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class AgentStats : MonoBehaviour
    {
        [SerializeField]  private int _hunger;
        public int hunger
        {
            get {  return _hunger; }
            set 
            {
                _hunger = Mathf.Clamp(value, 0, 100);
            }
        }

        [SerializeField] private int _energy;
        public int energy
        {
            get {  return _energy; }
            set 
            {
                _energy = value;
            }
        }

        [SerializeField] private int _money;
        public int money
        {
            get {  return _money; }
            set 
            {
                _money = value;
            }
        }

        [SerializeField] private int _stress;
        public int stress
        {
            get {  return _stress; }
            set 
            {
                _stress = value;
            }
        }

        [SerializeField] private int _bowels;
        public int bowels
        {
            get {  return _bowels; }
            set 
            {
                _bowels = value;
            }
        }

        // Initialize stats to starting values
        void Start()
        {
            hunger = Random.Range(0, 100);
            energy = Random.Range(0, 100);
            stress = Random.Range(0, 100);
            bowels = Random.Range(0, 100);
            money  = 0;
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

        public void UpdateBowels(int bowelsLevel)
        {
            if(bowels + bowelsLevel <= 0)
            {
                bowels = 0;
                return;
            }
            bowels += bowelsLevel;
        }

        public void UpdateStress(int stressLevel)
        {
            if(stress + stressLevel <= 0)
            {
                stress = 0;
                return;
            }
            stress += stressLevel;
        }

        public void UpdateMoney(int amount)
        {
            if(money + amount <= 0)
            {
                money = 0;
                return;
            }
            money += amount;
        }

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
            hunger += 3;
        }

        [SerializeField] private float timeToDecreaseRent= 12f; // how many seconds to wait
        private float timeLeftRent; // remaining time left 
        public void PayRent()
        {
            if (timeLeftRent > 0)
            {
                timeLeftRent -= Time.deltaTime;
                return;
            }
            timeLeftRent = timeToDecreaseRent;
            money -= 10;
            if(money < 0) money = 0;
        }
    }
}
