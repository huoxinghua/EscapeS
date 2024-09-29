using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        { 
            GameManager._points += 1;
            Debug.Log(GameManager._points);
            Destroy(gameObject);
        }
       
    }
}
