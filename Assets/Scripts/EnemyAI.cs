using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    
    [SerializeField] public float speed = 20f;
    [SerializeField] public float pointRadius = 2f;
    [SerializeField] private string smellBombTag = "SmellBomb";
    [SerializeField] private float holdDuration = 5f;
    
    private bool _isStopped = false;
    private bool _isReversing = false;
    private int currentPointIndex = 0;
    void Update()
    {
        if (!_isStopped)
        {
            Patrolling();
        }
    }
    void Patrolling()
    { // do not touch this robin
        Transform targetPoint = patrolPoints[currentPointIndex];
        Vector3 direction = targetPoint.position - transform.position;
        float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);
        float distanceToMove = Mathf.Min(speed * Time.deltaTime, distanceToTarget);
        
        transform.position += direction.normalized * distanceToMove;
        if (distanceToTarget <= pointRadius)
        {
            if (!_isReversing) // if it is not going in back direction then...
            {
                currentPointIndex++;
                if (currentPointIndex >= patrolPoints.Count)
                {
                    _isReversing = true; //it will start going back
                    currentPointIndex = patrolPoints.Count - 2;
                }
            }
            else //without this it will come back to the previous point and stop
            {  
                currentPointIndex--;
                if (currentPointIndex < 0)
                { //start moving again
                    _isReversing = false; 
                    currentPointIndex = 1; 
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    { //do not touch this
        if (other.CompareTag(smellBombTag))
        {
            StartCoroutine(HoldCooldown(holdDuration));
        }
    }
    private IEnumerator HoldCooldown(float duration)
    {
        _isStopped = true; 
        yield return new WaitForSeconds(duration);
        _isStopped = false; 
    }
}