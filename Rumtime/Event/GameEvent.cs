using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
    public abstract class GameEvent<T> : ScriptableObject
    {
        private List<GameEventListener<T>> listeners = new List<GameEventListener<T>>();

        public virtual void Raise(T value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i] != null)
                {
                    listeners[i].OnEventRaised(value);
                }
                else
                {
                    listeners.RemoveAt(i);
                }
            }
        }

        public virtual void RegisterListener(GameEventListener<T> listener)
        {
            if (listener != null && !listeners.Contains(listener))
            {
                listeners.Add(listener);            
            }
        }

        public virtual void UnregisterListener(GameEventListener<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}