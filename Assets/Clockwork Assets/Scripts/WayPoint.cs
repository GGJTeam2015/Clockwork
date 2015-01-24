using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviourExtend
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawCube(TransformCached.position, Vector3.one/2.0f);
    }
}
