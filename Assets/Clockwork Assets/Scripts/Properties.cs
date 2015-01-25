using Assets.Scripts;
using UnityEngine;

public class Properties : MonoBehaviourExtend, IDestructable
{
    [SerializeField] protected int startHealth = 100;


    protected int health;

    public virtual void Start()
    {
        health = startHealth;
    }

    public int getHealth() { return health; }
    public int getMaxHealth() { return startHealth; }

    public virtual void Damage(int damageAmount)
    {
        health -= damageAmount;

    }
}
