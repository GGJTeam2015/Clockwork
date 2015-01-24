using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviourExtend
{
/*    [SerializeField] private Transform target = null;
    [SerializeField] private AIState currentState = null;*/
    [SerializeField] private int damageToPlayer = 200;

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

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<PlayerProperties>() != null)
        {
            // It is a player! Deal damage to that looser!
            coll.gameObject.GetComponent<PlayerProperties>().Damage(damageToPlayer);

            // Destroy this
            Destroy(this.gameObject);
        }
    }

    void LateUpdate()
    {
/*        if (target)
        {
            agent.SetDestination(target.position);
        }*/
    }
}
