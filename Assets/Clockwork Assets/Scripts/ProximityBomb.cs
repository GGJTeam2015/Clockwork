using System;
using UnityEngine;

public class ProximityBomb : StandardBomb
{
    [SerializeField] private float proximityRadius = 6.0f;

    public override void Update()
    {
        base.Update();
    }
}
