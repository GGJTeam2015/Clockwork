using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviourExtend
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float damping = 10.0f;
    [SerializeField] private Vector3 offset = Vector3.zero;

    private Vector3 nextPosition;

	void FixedUpdate () 
    {
	    if (target)
	    {
	        nextPosition = target.position;
	        nextPosition += offset;
	        TransformCached.position = Vector3.Lerp(TransformCached.position, nextPosition, damping*Time.fixedDeltaTime);
	    }
	}
}
