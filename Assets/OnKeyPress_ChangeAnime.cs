using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress_ChangeAnime : MonoBehaviour
{
    float vx;  // 수평 이동 속도
    float vy;  // 수직 이동 속도
    float AxisH;  // 수평 입력 값 (-1에서 1 사이)
    float AxisV;  // 수직 입력 값 (-1에서 1 사이)

    public float speed = 1;  // 캐릭터 이동 속도 조절 매개변수

    Animator animatorController;  // Animator 컴포넌트
    // 각 방향에 따른 애니메이션 이름 설정
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

    string nowAnime = "";  // 현재 재생 중인 애니메이션 이름
    string oldAnime = "";  // 이전에 재생 중이었던 애니메이션 이름

    // Start is called before the first frame update
    void Start()
    {
        vx = 0;
        vy = 0;
        animatorController = GetComponent<Animator>();  // 현재 게임 오브젝트의 Animator 컴포넌트 가져오기
        nowAnime = stopAnime;  // 시작할 때 정지 애니메이션 설정
        oldAnime = nowAnime;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nowAnime);
        // 수평 및 수직 입력 값 감지
        AxisH = Input.GetAxisRaw("Horizontal");
        AxisV = Input.GetAxisRaw("Vertical");

        // 입력 값을 기반으로 캐릭터의 이동 속도 계산
        vx = AxisH * speed;
        vy = AxisV * speed;

        // 입력 방향에 따라 재생할 애니메이션 설정
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
            // nowAnime = stopAnime; // 입력이 없을 때 정지 애니메이션 설정

        }
        
    }

    // FixedUpdate is called at fixed intervals, recommended for physics operations
    private void FixedUpdate()
    {
        // 캐릭터 이동
        this.transform.Translate(vx / 50, vy / 50, 0);  // 픽셀 단위의 속도로 이동

        // 현재 재생 중인 애니메이션이 변경되었을 때만 애니메이션 변경
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animatorController.Play(nowAnime);  // Animator에서 새로운 애니메이션 재생
        }
    }
}
