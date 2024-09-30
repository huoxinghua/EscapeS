using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
   [SerializeField] public List<GameObject> CollectDisplay;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        { 
            GameManager._points += 1;
            Debug.Log(GameManager._points);
            Destroy(gameObject);
            if (CollectDisplay.Count >= GameManager._points)
            {
                GameObject collectDisplay = CollectDisplay[GameManager._points - 1];
                if (collectDisplay != null && !collectDisplay.activeInHierarchy)
                {
                    collectDisplay.SetActive(true); 
                }
            }
        }
    }
}
