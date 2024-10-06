using ScriptableObjectArchitecture;
using UnityEngine;

public class Simple2DController : MonoBehaviour
{
    // 이동 속도
    public IntVariable moveSpeed;

    // Rigidbody2D 컴포넌트 참조
    private Rigidbody2D rb;

    // 이동 방향을 저장할 변수
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2D 컴포넌트를 가져옴
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 입력 받기 (수평, 수직축: 키보드의 방향키나 WASD 키)
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    // FixedUpdate는 물리 연산을 처리하므로 Rigidbody2D는 여기에서 이동
    void FixedUpdate()
    {
        // 캐릭터 이동
        rb.MovePosition( rb.position + movement * moveSpeed.Value * Time.fixedDeltaTime);
    }
}
