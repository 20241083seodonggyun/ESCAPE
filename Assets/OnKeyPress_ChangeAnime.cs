using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress_ChangeAnime : MonoBehaviour
{
    float vx;  // ���� �̵� �ӵ�
    float vy;  // ���� �̵� �ӵ�
    float AxisH;  // ���� �Է� �� (-1���� 1 ����)
    float AxisV;  // ���� �Է� �� (-1���� 1 ����)

    public float speed = 1;  // ĳ���� �̵� �ӵ� ���� �Ű�����

    Animator animatorController;  // Animator ������Ʈ
    // �� ���⿡ ���� �ִϸ��̼� �̸� ����
    public string upAnime = "PLUP";
    public string downAnime = "PLDOWN";
    public string rightAnime = "PLRIGHT";
    public string leftAnime = "PLLEFT";
    public string stopAnime = "STOP";
    public string leftupAnime = "PLUPL";
    public string rightupAnime = "PLUPR";
    public string leftdownAnime = "PLDOWNL";
    public string righdownAnime = "PLDOWNR";

    string nowAnime = "";  // ���� ��� ���� �ִϸ��̼� �̸�
    string oldAnime = "";  // ������ ��� ���̾��� �ִϸ��̼� �̸�

    // Start is called before the first frame update
    void Start()
    {
        vx = 0;
        vy = 0;
        animatorController = GetComponent<Animator>();  // ���� ���� ������Ʈ�� Animator ������Ʈ ��������
        nowAnime = stopAnime;  // ������ �� ���� �ִϸ��̼� ����
        oldAnime = nowAnime;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �� ���� �Է� �� ����
        AxisH = Input.GetAxisRaw("Horizontal");
        AxisV = Input.GetAxisRaw("Vertical");

        // �Է� ���� ������� ĳ������ �̵� �ӵ� ���
        vx = AxisH * speed;
        vy = AxisV * speed;

        // �Է� ���⿡ ���� ����� �ִϸ��̼� ����
        if (AxisH > 0 && AxisV > 0)
        {
            nowAnime = rightupAnime;
        }
        else if (AxisH > 0 && AxisV < 0)
        {
            nowAnime = righdownAnime;
        }
        else if (AxisH < 0 && AxisV < 0)
        {
            nowAnime = leftdownAnime;
        }
        else if (AxisH < 0 && AxisV > 0)
        {
            nowAnime = leftupAnime;
        }
        else if (AxisH > 0)
        {
            nowAnime = rightAnime;
        }
        else if (AxisH < 0)
        {
            nowAnime = leftAnime;
        }
        else if (AxisV > 0)
        {
            nowAnime = upAnime;
        }
        else if (AxisV < 0)
        {
            nowAnime = downAnime;
        }
        else
        {
            nowAnime = stopAnime;  // �Է��� ���� �� ���� �ִϸ��̼� ����
        }
    }

    // FixedUpdate is called at fixed intervals, recommended for physics operations
    private void FixedUpdate()
    {
        // ĳ���� �̵�
        this.transform.Translate(vx / 50, vy / 50, 0);  // �ȼ� ������ �ӵ��� �̵�

        // ���� ��� ���� �ִϸ��̼��� ����Ǿ��� ���� �ִϸ��̼� ����
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animatorController.Play(nowAnime);  // Animator���� ���ο� �ִϸ��̼� ���
        }
    }
}
