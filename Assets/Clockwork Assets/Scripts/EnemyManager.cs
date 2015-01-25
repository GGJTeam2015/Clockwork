using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance = null;

    [SerializeField] private int maxEnemyAtTime = 0;

    private int currentEnemyCount = 0;

    public static EnemyManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<EnemyManager>();
/*

                if (!instance)
                {
                    GameObject container = new GameObject("EnemyManagerContainer");
                    instance = container.AddComponent<EnemyManager>();
                }
*/

            }

            return instance;
        }
    }

    public bool CanSpawnEnemies()
    {
        return currentEnemyCount < maxEnemyAtTime;
    }

    public bool IncEnemy()
    {
        bool available = CanSpawnEnemies();

        if (available) ++currentEnemyCount;

        return available;
    }

    public bool DecEnemy()
    {
        bool available = currentEnemyCount > 0;

        if (available) --currentEnemyCount;

        return available;
    }
}
