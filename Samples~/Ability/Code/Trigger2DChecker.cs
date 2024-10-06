using UnityEngine;
using UnityEngine.Events;

public class Trigger2DChecker : MonoBehaviour
{
    // 충돌시 발생할 UnityEvent
    public UnityEvent onPlayerEnterTrigger;

    // 충돌체가 트리거에 진입했을 때 호출되는 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트의 태그가 "Player"인지 확인
        if (other.CompareTag("Player"))
        {
            // UnityEvent 호출
            onPlayerEnterTrigger.Invoke();
        }
    }
}
