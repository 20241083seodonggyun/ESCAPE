using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hp : MonoBehaviour
{

    public static int pHp; // �÷��̾� hp����

    public static int maxHp = 10; // �÷��̾��� �ִ� ü��
    bool isDie = false;

    // Start is called before the first frame update
    void Start()
    {
        pHp = maxHp; // ���� ���۽� �ƽ� ü������ ����
    }

    // Update is called once per frame
    void Update()
    {
        if (pHp == 0) //hp�� 0�� �Ǿ����� Die�Լ� �۵�
        {
            if (!isDie)
            {
                Die();

                return;
            }
        }
    }

    void Die() // ���� hp�� 0�� �Ǿ����� ���� ����
    {
        isDie = true;

    }

    void OnCollisionEnter2D(Collision2D other) // Enemy �ױ׿� ���õ� ���� �浹�� �������� �޴� �Լ�
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); // �Լ��� ����

        }

    }
    void TakeDamage(int value) // �������� ������ �����ϴ� �Լ�
    {
        pHp -= value; 
        if (pHp <= 0)
        {
            Die();
        }
    }
}
