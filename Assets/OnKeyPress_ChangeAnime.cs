using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress_ChangeAnime : MonoBehaviour
{
    float vx;
    float vy;
    float AxisH;
    float AxisV;

    public float speed = 1;

    Animator animatorController;
    public string upAnime = "PLUP";
    public string downAnime = "PLDOWN";
    public string rightAnime = "PLRIGHT";
    public string leftAnime = "PLLEFT";
    public string stopAnime = "STOP";
    public string leftupAnime = "PLUPL";
    public string rightupAnime = "PLUPR";
    public string leftdownAnime = "PLUPDOWNL";
    public string rightdownAnime = "PLUPDOWNR";

    string nowAnime = "";
    string oldAnime = "";


    // Start is called before the first frame update
    void Start()
    {
        vx = 0;
        vy = 0;
        animatorController = GetComponent<Animator>();
        nowAnime = stopAnime;
        oldAnime = nowAnime;
    }

    // Update is called once per frame
    void Update()
    {
        AxisH = Input.GetAxisRaw("Horizontal");
        AxisV = Input.GetAxisRaw("Vertical");

        vx = AxisH * speed;
        vy = AxisV * speed;

        if (AxisH > 0)
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
        else if (AxisH == 0 && AxisV == 0)
        {
            nowAnime = stopAnime;
        }
        else if (AxisH > 0 && AxisV > 0)
        {
            nowAnime = rightupAnime;
        }
        else if (AxisH > 0 && AxisV < 0)
        {
            nowAnime = rightdownAnime;
        }
        else if(AxisH < 0 && AxisV < 0)
        {
            nowAnime = leftdownAnime; 
        }
        else if(AxisH < 0 && AxisV > 0)
        {
            nowAnime = leftupAnime;
        }








    }
    private void FixedUpdate()
    {
        this.transform.Translate(vx / 50, vy / 50, 0);
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animatorController.Play(nowAnime);
        }
    }
}
