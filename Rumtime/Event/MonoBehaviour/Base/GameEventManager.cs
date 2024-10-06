using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScriptableObjectArchitecture
{
    public abstract class GameEventManager<T> : MonoBehaviour
    {
        [SerializeField] protected List<GameEvent<T>> awakeEvents;
        [SerializeField] protected List<GameEvent<T>> startEvents;
        [SerializeField] protected List<GameEvent<T>> enableEvents;
        [SerializeField] protected List<GameEvent<T>> disableEvents;
        [SerializeField] protected List<GameEvent<T>> destroyEvents;

        protected virtual async void Awake()

        {
            if (awakeEvents != null && awakeEvents.Count > 0)
            {
                await RaiseEventsAsync(awakeEvents);
            }
        }

        protected virtual async void Start()
        {
            if (startEvents != null && startEvents.Count > 0)
            {
                await RaiseEventsAsync(startEvents);
            }
        }

        protected virtual async void OnEnable()
        {
            if (enableEvents != null && enableEvents.Count > 0)
            {
                await RaiseEventsAsync(enableEvents);
            }
        }

        protected virtual async void OnDisable()
        {
            if (disableEvents != null && disableEvents.Count > 0)
            {
                await RaiseEventsAsync(disableEvents);
            }
        }

        protected virtual async void OnDestroy()
        {
            if (destroyEvents != null && destroyEvents.Count > 0)
            {
                await RaiseEventsAsync(destroyEvents);
            }

            ClearEventLists();
        }

        protected virtual void ClearEventLists()
        {
            ReleaseAndClearEventList(awakeEvents);
            awakeEvents = null;

            ReleaseAndClearEventList(startEvents);
            startEvents = null;

            ReleaseAndClearEventList(enableEvents);
            enableEvents = null;

            ReleaseAndClearEventList(disableEvents);
            disableEvents = null;

            ReleaseAndClearEventList(destroyEvents);
            destroyEvents = null;
        }

        protected virtual void ReleaseAndClearEventList(List<GameEvent<T>> eventList)
        {
            if (eventList == null) return;

            eventList.Clear();

        }

        protected virtual async Task RaiseEventsAsync(List<GameEvent<T>> events)
        {
            if (events == null) return;

            var eventData = GetEventData();

            foreach (var gameEvent in events)
            {
                if (gameEvent != null)
                {
                    gameEvent.Raise(eventData);
                }
            }
        }

        protected abstract T GetEventData();
    }
}
