using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UtilityAI;

/*
    Updates the values on the agent UI 
*/

namespace UI 
{
    public class UpdateAgentStatsUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text actionScores;
        [SerializeField] private TMP_Text bestActionText;
        [SerializeField] private TMP_Text weatherText;

        void Start()
        {

        }
        public void UpdateActionScores(Action[] actions, string money)
        {
            string text = "";
            foreach(Action action in actions)
            {
                if(action is null) break;
                text += action.Name + ": " + action.score + "\n"; 
            }
            text += "Money: $" + money;
            actionScores.text = text;
        }

        public void UpdateBestAction(string action)
        {
            bestActionText.text = $"Action: { action }";
        }

        public void UpdateWeatherText(string weather)
        {
            weatherText.text = $"Weather: { weather }";
        }
    }
}
