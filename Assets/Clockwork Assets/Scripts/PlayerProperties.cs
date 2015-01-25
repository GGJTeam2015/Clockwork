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

        int destroyTime;
        GameObject effectPrefab = FxManager.Instance.GetEffectPrefab("die", out destroyTime);

        GameObject effect = Instantiate(effectPrefab, TransformCached.position + TransformCached.up, Quaternion.identity) as GameObject;

        loadLevelGUI.Instance.loadLevelWithDelay("loose", destroyTime);


        Destroy(gameObject);
    }

}
