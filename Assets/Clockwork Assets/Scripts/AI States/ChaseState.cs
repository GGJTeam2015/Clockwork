using UnityEngine;

public class ChaseState : AIState
{
    [SerializeField] private Enemy enemy = null;

    void OnTriggerExit(Collider col)
    {
        Debug.Log("Trigger exited");
        enemy.Target = null;
        NextState();
    }

    void LateUpdate()
    {
        if (enemy.Target)
        {
            agent.SetDestination(enemy.Target.position);
        }
    }
}