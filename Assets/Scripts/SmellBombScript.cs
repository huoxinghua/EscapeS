using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SmellBombScript : MonoBehaviour
{
    public float despawnTime = 5f;
    void Start()
    {
        Invoke("Exploded", despawnTime);
    }
    void Exploded()
    {
        Destroy(gameObject);
    }
 
}
