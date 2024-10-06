using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public class Thing : MonoBehaviour
    {   
        public ThingRuntimeSet RuntimeSet;

        protected virtual void OnEnable()
        {
            RuntimeSet.Add(this);
        }

        protected virtual void OnDisable()
        {
        }

        protected virtual void OnDestroy()
        {            
            RuntimeSet.Remove(this);
        }
    }
}