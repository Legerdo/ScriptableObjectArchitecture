using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    public class NonGenericGameEventListener : MonoBehaviour
    {
        public NonGenericGameEvent nonGenericGameEvent;
        
        public UnityEvent response;

        protected virtual void OnEnable()
        {
            if (nonGenericGameEvent != null)
            {
                nonGenericGameEvent.RegisterListener(this);
            }
        }

        protected virtual void OnDisable()
        {
            if (nonGenericGameEvent != null)
            {
                nonGenericGameEvent.UnregisterListener(this);
            }
        }

        public virtual void OnEventRaised()
        {
            response.Invoke();
        }
    }
}