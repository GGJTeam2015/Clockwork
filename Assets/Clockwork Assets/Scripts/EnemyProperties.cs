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

        Destroy(this.gameObject);
    }
}
