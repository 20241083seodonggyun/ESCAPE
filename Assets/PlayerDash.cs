using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f; // �뽬 �ӵ�
    public float dashDuration = 0.5f; // �뽬 ���� �ð�
    public float dashCooldown = 2f; // �뽬 ��Ÿ��
    private float dashTimer; // �뽬 Ÿ�̸�
    private float cooldownTimer; // ��Ÿ�� Ÿ�̸�
    private bool isDashing; // ���� �뽬 ������ ����

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTimer = 0f; // �뽬 Ÿ�̸� �ʱ�ȭ
        cooldownTimer = 0f; // ��Ÿ�� Ÿ�̸� �ʱ�ȭ
    }

    void Update()
    {
        // �뽬 ��Ÿ���� �����ִ� ���ȿ��� ��Ÿ�� Ÿ�̸Ӹ� ���ҽ�Ų��.
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && cooldownTimer <= 0)
        {
            // Space Ű�� ������ �뽬 ��Ÿ���� ������ �뽬�� �����Ѵ�.
            Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            StartCoroutine(Dash(moveDirection));
        }
    }

    IEnumerator Dash(Vector2 dashDirection)
    {
        isDashing = true; // �뽬 ���·� ����
        dashTimer = dashDuration; // �뽬 ���� �ð� ����

        while (dashTimer > 0)
        {
            // �뽬 ����� �ӵ��� �̵�
            rb.velocity = dashDirection * dashSpeed;
            dashTimer -= Time.deltaTime; // �뽬 Ÿ�̸� ����
            yield return null; // ���� �����ӱ��� ���
        }

        // �뽬�� ������ �ӵ��� 0���� �����Ͽ� �����.
        rb.velocity = Vector2.zero;
        isDashing = false; // �뽬 ���� ����

        // �뽬 ��Ÿ���� Ȱ��ȭ�Ѵ�.
        cooldownTimer = dashCooldown;
    }
}
