using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    [SerializeField] public float speed = 20f;
    [SerializeField] private int currentPointIndex = 0;
    [SerializeField] public float pointRadius = 2f;

    private bool _isStopped = false;
    void Update()
    {
        if (!_isStopped)
        {
            Patrolling();
        }
    }
    void Patrolling()
    {
        Transform targetPoint = patrolPoints[currentPointIndex];
        Vector3 direction = targetPoint.position - transform.position;
        float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);
        float distanceToMove = Mathf.Min(speed * Time.deltaTime, distanceToTarget);
        
        transform.position += direction.normalized * distanceToMove;
        if (distanceToTarget <= pointRadius)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Count;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SmellBomb"))
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