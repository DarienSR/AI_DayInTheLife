using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Environment; // access waypoint
/*
    This is the base class for all actions.
*/
namespace UtilityAI
{
    public abstract class Action : ScriptableObject
    {
        public string Name;

        private float _score;
        public float score
        {
            get { return _score; }
            set 
            {
                this._score = Mathf.Clamp01(value); // we normalize all action scores between 0 and 1.
            }
        }

        public Consideration[] considerations; // array of all considerations associated with the action

        public virtual void Awake()
        {
            score = 0;
        }

        // abstract class will have to be over-written by the action. 
        public abstract void PerformAction(AgentController agent); 
        public virtual void Perform(AgentController agent)
        {
            return;
        }

        
    }
}

