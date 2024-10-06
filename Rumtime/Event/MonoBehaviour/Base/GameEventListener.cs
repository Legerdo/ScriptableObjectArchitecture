using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    public class GameEventListener<T> : MonoBehaviour
    {
        public GameEvent<T> gameEvent;

        public UnityEvent<T> response;

        protected virtual void OnEnable()
        {    
            if (gameEvent != null)
            {
                gameEvent.RegisterListener(this);
                Debug.Log("게임 이벤트 로드 및 리스너 등록 완료.");
            }        
        }

        protected virtual void OnDisable()
        {
            if (gameEvent != null)
            {
                gameEvent.UnregisterListener(this);
            }
        }

        public virtual void OnEventRaised(T value)
        {
            response.Invoke(value);
        }
    }
}