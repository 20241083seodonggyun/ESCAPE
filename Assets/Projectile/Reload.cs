using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    SpriteRenderer Img_Renderer;
    public Sprite[] Image;
    int Sprite_Image = 0;

    // Start is called before the first frame update
    void Start()
    {
        Img_Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Animation();
    }

    void Animation()
    { 
        Img_Renderer.sprite = Image[Sprite_Image];
        if (Sprite_Image >= Image.Length - 1)
            Sprite_Image = 0;
        else
            Sprite_Image++;
    }
}
