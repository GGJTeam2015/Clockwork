using System;
using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviourExtend
{
    [Serializable]
    public class LayerPack
    {
        public string BodyLayer;
        public string RangeLayer;
    }

/*    [SerializeField] private Transform target = null;
    [SerializeField] private AIState currentState = null;*/
    [SerializeField] private int damageToPlayer = 200;
    [SerializeField] private LayerPack[] layers = null;
    [SerializeField] private GameObject rangeObject = null;

//    [SerializeField] private float chasingRange = 5.0f;

    private NavMeshAgent agent = null;
    public Transform Target { get; set; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        EnemyManager.Instance.IncEnemy();

        LayerPack pack = layers[UnityEngine.Random.Range(0, layers.Length)];
        gameObject.SetLayerRecursively(LayerMask.NameToLayer(pack.BodyLayer));
        rangeObject.layer = LayerMask.NameToLayer(pack.RangeLayer);
    }

    void OnDestroy()
    {
        EnemyManager.Instance.DecEnemy();
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
