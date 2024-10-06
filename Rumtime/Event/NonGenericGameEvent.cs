using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
    public abstract class NonGenericGameEvent : ScriptableObject
    {
        private List<NonGenericGameEventListener> listeners = new List<NonGenericGameEventListener>();

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i] != null)
                {
                    listeners[i].OnEventRaised();
                }
                else
                {
                    listeners.RemoveAt(i);
                }
            }
        }

        public void RegisterListener(NonGenericGameEventListener listener)
        {
            if (listener != null && !listeners.Contains(listener))
            {
                listeners.Add(listener);            
            }
        }

        public void UnregisterListener(NonGenericGameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}