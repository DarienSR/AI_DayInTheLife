using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace UI 
{
    public class UpdateAgentStatsUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text statsText;
        [SerializeField] private TMP_Text inventoryText;
        [SerializeField] private TMP_Text bestActionText;


        void Start()
        {

        }
        public void UpdateStatsText(int energy, int hunger)
        {
            statsText.text = $"Energy: { energy }\nHunger: { hunger }";
        }

        public void UpdateInventoryText(int food, int wood)
        {
            inventoryText.text = $"Food: { food }\nWood: { wood }";
        }

        public void UpdateBestAction(string action)
        {
            bestActionText.text = $"Action: { action }";
        }

    }
}
