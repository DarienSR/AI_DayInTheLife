using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    All considerations will inherit this base class.
*/

namespace UtilityAI
{
    public abstract class Consideration : ScriptableObject
    {
        public string consideration;
        private float _score;
        public float score 
        {
            get { return _score; }
            set { this._score = Mathf.Clamp01(value); } // normalizae score between 0 and 1
        }

        public virtual void Awake()
        {
            score = 0;
        }

        // each consideration will override this function. They will have their own custom scoring scheme.
        public abstract float ScoreConsideration(AgentController agent);
    }
}

