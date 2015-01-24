using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class AIState : MonoBehaviourExtend
{
    [SerializeField] protected AIState nextState = null;

    protected NavMeshAgent agent = null;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public virtual AIState NextState()
    {
        this.enabled = false;
        nextState.enabled = true;
        return nextState;
    }
}
