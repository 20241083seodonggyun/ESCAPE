using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭터 이동 속도

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 키보드 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal"); // A와 D 키 입력 (좌우)
        float verticalInput = Input.GetAxis("Vertical"); // W와 S 키 입력 (위아래)

        // 이동 방향 설정
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // 실제 이동 처리
        rb.velocity = moveDirection * moveSpeed;
    }
}
