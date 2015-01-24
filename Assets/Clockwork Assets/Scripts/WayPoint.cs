using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviourExtend
{
    private static readonly List<WayPoint> wayPoints = new List<WayPoint>();

    public static WayPoint[] WayPoints
    {
        get { return wayPoints.ToArray(); }
    }

    void Awake()
    {
        wayPoints.Add(this);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawCube(TransformCached.position, Vector3.one/2.0f);
    }
}
