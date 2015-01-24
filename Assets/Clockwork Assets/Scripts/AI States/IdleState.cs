using UnityEngine;

public class IdleState : AIState
{
    void OnEnable()
    {
        SetNewCourse();
    }

    void Update()
    {
        if (Mathf.Approximately(agent.speed, 0))
        {
            SetNewCourse();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger entered");
        NextState();
    }

    private void SetNewCourse()
    {
        if (WayPoint.WayPoints.Length > 0)
        {
            WayPoint wayPoint = WayPoint.WayPoints[Random.Range(0, WayPoint.WayPoints.Length)];
            agent.SetDestination(wayPoint.TransformCached.position);
        }
    }
}