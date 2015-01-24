using UnityEngine;

public class IdleState : AIState
{
    [SerializeField] private Enemy enemy = null;

    void OnEnable()
    {
        SetNewCourse();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.2f)
        {
            SetNewCourse();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger entered");
        enemy.Target = col.transform;
        NextState();
    }

    private void SetNewCourse()
    {
        if (WayPoint.WayPoints.Length > 0)
        {
            WayPoint wayPoint = WayPoint.WayPoints[Random.Range(0, WayPoint.WayPoints.Length)];
            
            if (agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
            }

            agent.SetDestination(wayPoint.TransformCached.position);
        }
    }
}