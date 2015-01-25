using UnityEngine;
using System.Collections;

public class StandardBomb : MonoBehaviourExtend
{
    [SerializeField] private int damageAmount = 15;
    [SerializeField] private float damageRadius = 10.0f;
    [SerializeField] private float countDownSec = 3.0f;

    public virtual void Update()
    {
        if (countDownSec < 0)
        {
            Explode();
        }
        else
        {
            countDownSec -= Time.deltaTime;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        Gizmos.DrawWireSphere(TransformCached.position, damageRadius);
    }

    protected void Explode()
    {
        Collider[] colls = Physics.OverlapSphere(TransformCached.position, this.damageRadius);

        foreach (Collider collider1 in colls)
        {
            collider1.SendMessage("Damage", damageAmount, SendMessageOptions.DontRequireReceiver);
        }

        int destroyTime;
        GameObject explosionPrefab = FxManager.Instance.GetEffectPrefab("explosion", out destroyTime);

        GameObject explosionEffect = Instantiate(explosionPrefab, TransformCached.position + TransformCached.up, Quaternion.identity) as GameObject;
        Destroy(explosionEffect, destroyTime);
        Destroy(gameObject);
    }
}
