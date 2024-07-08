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
    public string upAnime = "Up";
    public string downAnime = "Down";
    public string rightAnime = "Right";
    public string leftAnime = "Left";
    public string stopAnime = "Idle";
    public string leftupAnime = "UpL";
    public string rightupAnime = "UpR";
    public string leftdownAnime = "DownL";
    public string rightdownAnime = "RightDown";
    public string upstopAnime = "UpStop";
    public string downstopAnime = "DownStop";
    public string uprstopAnime = "UpRStop";
    public string uplstopAnime = "UpLStop";
    public string downlstopAnime = "DownLStop";
    public string downrstopAnime = "DownRStop";
    public string leftstopAnime = "LeftStop";
    public string rightstopAnime = "RightStop";

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
        Debug.Log(nowAnime);
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
            nowAnime = rightdownAnime;
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
            
            if(oldAnime == upAnime)
            {
                
                nowAnime = upstopAnime;
            }
            else if(oldAnime == downAnime)
            {
                
                nowAnime = downstopAnime;
            }
            else if (oldAnime == rightupAnime)
            {

                nowAnime = uprstopAnime;
            }
            else if (oldAnime == leftupAnime)
            {

                nowAnime = uplstopAnime;
            }
            else if (oldAnime == leftdownAnime)
            {

                nowAnime = downlstopAnime;
            }
            else if (oldAnime == rightdownAnime)
            {

                nowAnime = downrstopAnime;
            }
            else if (oldAnime == leftAnime)
            {

                nowAnime = leftstopAnime;
            }
            else if (oldAnime == rightAnime)
            {

                nowAnime = rightstopAnime;
            }
            // nowAnime = stopAnime; // �Է��� ���� �� ���� �ִϸ��̼� ����

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
