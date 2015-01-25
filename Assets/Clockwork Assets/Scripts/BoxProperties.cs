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

            // Choose one player
            if(Random.Range(0,1) == 0)
            {
                item.layer = LayerMask.NameToLayer("NPC1");
            }

            else
            {
                item.layer = LayerMask.NameToLayer("NPC2");
            }
            
            Vector3 randRot = new Vector3( Random.Range(0,90), Random.Range(0,90), Random.Range(0,90) );
            Instantiate(item, this.transform.position, Quaternion.Euler(randRot));
        }

        ///TODO: Add destroy effect

        // Destroy the box
        Destroy(this.gameObject);
    }
}
