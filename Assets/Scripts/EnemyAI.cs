using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
      [SerializeField] public List<Transform> patrolPoints; 
      [SerializeField] public float speed = 20f;     
      [SerializeField] private int currentPointIndex = 0;  
      [SerializeField] public float pointRadius = 2f;   
      [SerializeField] private LayerMask smellBomb;
      
      private bool _isStopped = false;
       void Update()
       {
           if (!_isStopped && patrolPoints.Count > 0)
           {
               Patrolling();
           }
       }
       void Patrolling()
       {
           Transform targetPoint = patrolPoints[currentPointIndex];
           Vector3 direction = targetPoint.position - transform.position;
           transform.position += direction.normalized * (speed * Time.deltaTime);

           if (Vector3.Distance(transform.position, targetPoint.position) < pointRadius)
           {
               currentPointIndex = (currentPointIndex + 1) % patrolPoints.Count;
           }
       }
       void OnTriggerEnter(Collider other)
       {
           if (((1 << other.gameObject.layer) & smellBomb) != 0) 
           {
               StartCoroutine(HoldCooldown(5f)); 
           }
       }

       private IEnumerator HoldCooldown(float duration) 
       {
           _isStopped = true; 
           yield return new WaitForSeconds(duration); 
           _isStopped = false; 
       }
}
