using UnityEngine;
using System.Collections;

public class ProximityMine : ProximityBomb
{

	// This is a proximity bomb. So it will not be visible unless it is
	// triggered.

	protected override void Start()
	{
		base.Start();

		// Plus... make this invisible
        transform.GetChild(0).renderer.enabled = false;
	}

	protected override void OnTriggerEnter(Collider coll)
	{
		base.OnTriggerEnter(coll);

        // Is it an enemy or player?
        if (coll.GetComponent<EnemyProperties>() != null
            || coll.GetComponent<PlayerProperties>() != null)
        {
            // Plus.. Make this visible
            transform.GetChild(0).renderer.enabled = true;
        }
	}
	
}
