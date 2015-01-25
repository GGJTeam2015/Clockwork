using UnityEngine;
using System.Collections;

public class EnemyProperties : Properties {

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
        Debug.Log("An enemy died");

        // Drop item?
        GameObject item = SpacecraftItemControl.Inst.giveMeAnItem();

        if (item != null)
        {
            // Item Dropped!

            // Choose one player
            if (Random.Range(0, 1) == 0)
            {
                item.layer = LayerMask.NameToLayer("NPC1");
            }

            else
            {
                item.layer = LayerMask.NameToLayer("NPC2");
            }

            Instantiate(item, this.transform.position, Quaternion.identity);
        }

        int destroyTime;
        GameObject effectPrefab = FxManager.Instance.GetEffectPrefab("destroy", out destroyTime);

        GameObject effect = Instantiate(effectPrefab, TransformCached.position + TransformCached.up, Quaternion.identity) as GameObject;

        Destroy(effect, destroyTime);

        Destroy(this.gameObject);
    }
}
