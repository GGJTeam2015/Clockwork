using UnityEngine;

public class ChaseState : AIState
{
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger entered");
    }
}