using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{   
    public float Speed = .2f;
    public int Direction = 0;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Invoke("Destroy", 5);
        this.transform.Translate(Speed, 0, 0);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}