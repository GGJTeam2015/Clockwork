using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviourExtend
{
//    [SerializeField] private Transform target = null;
//    [SerializeField] private AIState currentState = null;
//    [SerializeField] private float chasingRange = 5.0f;

    private NavMeshAgent agent = null;

    public Transform Target { get; set; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

//        Gizmos.DrawWireSphere(TransformCached.position, chasingRange);
    }

    void LateUpdate()
    {
        /*if (target)
        {
            agent.SetDestination(target.position);
        }*/
    }
}
