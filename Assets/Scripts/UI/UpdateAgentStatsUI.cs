using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UI 
{
    public class UpdateAgentStatsUI : MonoBehaviour
    {
        [SerializeField] private Text statsText;
        [SerializeField] private Text inventoryText;
        [SerializeField] private Text bestActionText;

        void Start()
        {

        }
        public void UpdateStatsText(int energy, int hunger)
        {
            statsText.text = $"Energy: { energy } ||||  Hunger: { hunger }";
        }

        public void UpdateInventoryText(int food, int wood)
        {
            inventoryText.text = $"Food: { food } |||| Wood: { wood }";
        }

        public void UpdateBestAction(string action)
        {
            bestActionText.text = $"Best Action: { action }";
        }
    }
}
