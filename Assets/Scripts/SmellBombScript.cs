using System;
using UnityEngine;

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
