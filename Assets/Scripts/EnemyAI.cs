using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
      [SerializeField] public List<Transform> patrolPoints = new List<Transform>(); 
      [SerializeField] public float speed = 20f;     
      [SerializeField]  private int currentPointIndex = 0;  
      [SerializeField] public float pointRadius = 0.2f;   
       
       void Update()
       {
           //dont touch this
            Transform targetPoint = patrolPoints[currentPointIndex];
            Vector3 direction = targetPoint.position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;
           
            if (Vector3.Distance(transform.position, targetPoint.position) < pointRadius)
            {
                currentPointIndex = (currentPointIndex + 1) % patrolPoints.Count; 
            }
           
       }
       public void AddPatrolPoint(Transform newPoint)//dont touch this too
       {
           patrolPoints.Add(newPoint);
       }
}
