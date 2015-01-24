using System;
using UnityEngine;

public class ProximityBomb : StandardBomb
{
    [SerializeField] private float proximityRadius = 6.0f;
    private bool isTriggered = false;

    // Proximity bomb is different from standart bomb:
    // * It will trigger when you close to that

    void Start()
    {
        // Increase the trigger radius so when player or enemy enters it,
        // we understand that it is in radius and we trigger the bomb
        this.GetComponent<SphereCollider>().radius = proximityRadius;
    }

    public override void Update()
    {
        // If triggered, let base class handle the countdown and explotion
        if (isTriggered)
        {
            base.Update();
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Enter");

        // Is it an enemy or player?
        if (coll.GetComponent<EnemyProperties>() != null
            || coll.GetComponent<PlayerProperties>() != null)
        {
             // Trigger!
            isTriggered = true;
        }
    }
}
