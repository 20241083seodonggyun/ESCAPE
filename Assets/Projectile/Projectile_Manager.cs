using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile_Manager : MonoBehaviour
{
    public GameObject projectile;
    public int Launch_Count = 0;

    void Start()
    {
        Launch_Count = 0;
    }

    void FixedUpdate()
    {
        Invoke("LaunchProjectile", 1);
    }

    void LaunchProjectile()
    {
        Instantiate(projectile);
        Launch_Count++;
        CancelInvoke("LaunchProjectile");
    }
}