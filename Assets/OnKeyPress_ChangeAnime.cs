using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnKeyPress_ChangeAnime : MonoBehaviour
{
    float vx;
    float vy;
    float AxisH;
    float AxisV;

    public float speed = 1;

    Animator animatorController;
    public string upAnime = "Up";
    public string downAnime = "Down";
    public string rightAnime = "Right";
    public string leftAnime = "Left";
    public string leftupAnime = "UpL";
    public string rightupAnime = "UpR";
    public string leftdownAnime = "DownL";
    public string rightdownAnime = "RightDown";


    string nowAnime = "";
    string oldAnime = "";


    // Start is called before the first frame update
    void Start()
    {
        vx = 0;
        vy = 0;
        animatorController = GetComponent<Animator>();
        nowAnime = downAnime;
        oldAnime = nowAnime;
    }

    // Update is called once per frame
    void Update()
    {
        AxisH = Input.GetAxisRaw("Horizontal");
        AxisV = Input.GetAxisRaw("Vertical");

        vx = AxisH * speed;
        vy = AxisV * speed;

        if (AxisH > 0 && AxisV >0)
        {
            nowAnime = rightupAnime;
        }
        else if(AxisH > 0 && AxisV < 0)
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

        animaplay();
        







    }
    
    private void animaplay()
    {
        this.transform.Translate(vx / 50, vy / 50, 0);
    if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animatorController.Play(nowAnime);
        }
    }
    /*private void FixedUpdate()
    {
        this.transform.Translate( vx, vy, 0);
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animatorController.Play(nowAnime);
        }
    }*/
}
