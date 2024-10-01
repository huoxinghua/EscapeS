using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
   [SerializeField] public List<GameObject> CollectDisplay;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        { 
            GameManager. Points += 1;
            Debug.Log(GameManager.Points);
            Destroy(gameObject);
            
            if (CollectDisplay.Count >= GameManager.Points)
            {
                GameObject collectDisplay = CollectDisplay[GameManager.Points - 1];
                
                if (collectDisplay != null && !collectDisplay.activeInHierarchy)
                {
                    collectDisplay.SetActive(true); 
                    
                }
            }
        }
    }
}
