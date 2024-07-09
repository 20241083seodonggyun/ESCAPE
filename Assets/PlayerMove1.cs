using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // ĳ���� �̵� �ӵ�

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Ű���� �Է� �ޱ�
        float horizontalInput = Input.GetAxis("Horizontal"); // A�� D Ű �Է� (�¿�)
        float verticalInput = Input.GetAxis("Vertical"); // W�� S Ű �Է� (���Ʒ�)

        // �̵� ���� ����
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // ���� �̵� ó��
        rb.velocity = moveDirection * moveSpeed;
    }
}
