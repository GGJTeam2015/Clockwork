using Assets.Scripts;
using UnityEngine;
using System.Collections;

public class MetaPoint : MonoBehaviourExtend
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(TransformCached.position, 0.5f);
    }

    public void CreateMeta(MetaType metaType)
    {

/*        if (metaPrefab)
        {
            Instantiate(metaPrefab, TransformCached.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("Meta prefab is empty");
        }*/

        switch (metaType)
        {
            case MetaType.Spawner:
                gameObject.AddComponent<SpawnPoint>();
                break;

            case MetaType.Waypoint:
                gameObject.AddComponent<WayPoint>();
                break;
        }

        Destroy(this);
    }
}
