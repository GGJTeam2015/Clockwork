using UnityEngine;

public class MonoBehaviourExtend : MonoBehaviour
{
    private Transform transformCached = null;
    private Rigidbody rigidbodyCached = null;

    public Transform TransformCached
    {
        get { return transformCached ?? (transformCached = transform); }
    }

    public Rigidbody RigidbodyCached
    {
        get { return rigidbodyCached ?? (rigidbodyCached = rigidbody); }
    }
}
