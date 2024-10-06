using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjectArchitecture
{
    public class DamageTest : MonoBehaviour
    {
        public FloatVariable health;
        
        void Update()
        {
            if ( Input.GetKeyDown(KeyCode.Space))
            {
                health.ApplyChange(-10);
            
                Debug.Log(health.Value);
            }

            if ( Input.GetKeyDown(KeyCode.F))
            {
                health.ApplyChange(+10);
            
                Debug.Log(health.Value);
            }
        }
    }
}