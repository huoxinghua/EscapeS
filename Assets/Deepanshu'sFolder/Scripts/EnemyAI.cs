using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
      [SerializeField] public List<Transform> patrolPoints; 
      [SerializeField] public float speed = 20f;     
      [SerializeField] private int currentPointIndex = 0;  
      [SerializeField] public float pointRadius = 2f;   
       
       void Update()
       {
           //dont touch this
            Transform targetPoint = patrolPoints[currentPointIndex];
            Vector3 direction = targetPoint.position - transform.position;
            transform.position += direction.normalized * (speed * Time.deltaTime);
           
            if (Vector3.Distance(transform.position, targetPoint.position) < pointRadius)
            {
                currentPointIndex = (currentPointIndex + 1) % patrolPoints.Count; 
            }
           
       }
}
