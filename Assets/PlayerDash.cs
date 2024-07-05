using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f; // 대쉬 속도
    public float dashDuration = 0.5f; // 대쉬 지속 시간
    public float dashCooldown = 2f; // 대쉬 쿨타임
    private float dashTimer; // 대쉬 타이머
    private float cooldownTimer; // 쿨타임 타이머
    private bool isDashing; // 현재 대쉬 중인지 여부

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTimer = 0f; // 대쉬 타이머 초기화
        cooldownTimer = 0f; // 쿨타임 타이머 초기화
    }

    void Update()
    {
        // 대쉬 쿨타임이 남아있는 동안에는 쿨타임 타이머를 감소시킨다.
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && cooldownTimer <= 0)
        {
            // Space 키를 누르고 대쉬 쿨타임이 끝나면 대쉬를 시작한다.
            Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            StartCoroutine(Dash(moveDirection));
        }
    }

    IEnumerator Dash(Vector2 dashDirection)
    {
        isDashing = true; // 대쉬 상태로 변경
        dashTimer = dashDuration; // 대쉬 지속 시간 설정

        while (dashTimer > 0)
        {
            // 대쉬 방향과 속도로 이동
            rb.velocity = dashDirection * dashSpeed;
            dashTimer -= Time.deltaTime; // 대쉬 타이머 감소
            yield return null; // 다음 프레임까지 대기
        }

        // 대쉬가 끝나면 속도를 0으로 설정하여 멈춘다.
        rb.velocity = Vector2.zero;
        isDashing = false; // 대쉬 상태 종료

        // 대쉬 쿨타임을 활성화한다.
        cooldownTimer = dashCooldown;
    }
}
