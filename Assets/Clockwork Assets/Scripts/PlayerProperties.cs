using UnityEngine;

public class PlayerProperties : Properties
{
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
        Debug.Log("I died");
    }
}
