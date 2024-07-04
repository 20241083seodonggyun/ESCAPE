using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hp : MonoBehaviour
{

    public static int pHp; // 플레이어 hp상태

    public static int maxHp = 10; // 플레이어의 최대 체력
    bool isDie = false;

    // Start is called before the first frame update
    void Start()
    {
        pHp = maxHp; // 게임 시작시 맥스 체력으로 변경
    }

    // Update is called once per frame
    void Update()
    {
        if (pHp == 0) //hp가 0이 되었을때 Die함수 작동
        {
            if (!isDie)
            {
                Die();

                return;
            }
        }
    }

    void Die() // 이후 hp가 0이 되었을때 죽음 구현
    {
        isDie = true;

    }

    void OnCollisionEnter2D(Collision2D other) // Enemy 테그에 관련된 적과 충돌시 데미지를 받는 함수
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); // 함수에 리턴

        }

    }
    void TakeDamage(int value) // 데미지를 받을시 연산하는 함수
    {
        pHp -= value; 
        if (pHp <= 0)
        {
            Die();
        }
    }
}
