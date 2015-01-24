using UnityEngine;
using System.Collections;

public class BoxProperties : Properties {

    public override void Damage(int damageAmount)
    {
        base.Damage(damageAmount);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Drop item?
        GameObject item = SpacecraftItemControl.Inst.giveMeAnItem();
        if (item != null)
        {
            // Item Dropped!
            Instantiate(item, this.transform.position, Quaternion.identity);
        }

        // Destroy the box
        Destroy(this.gameObject);
    }
}
