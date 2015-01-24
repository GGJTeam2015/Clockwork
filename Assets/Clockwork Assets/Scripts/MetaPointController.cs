using Assets.Scripts;
using UnityEngine;

public class MetaPointController : MonoBehaviourExtend
{
    [SerializeField] private MetaPoint[] metaPoints = null;
    [SerializeField] private int spawnerCount = 0;
    [SerializeField] private int waypointCount = 0;

    void Awake()
    {
        if (spawnerCount + waypointCount > metaPoints.Length)
        {
            Debug.LogError("Total count must not exceed meta points array length");
            Destroy(this);
        }
    }

	void Start()
	{
	    MetaType[] metaTypes = new MetaType[metaPoints.Length];
	    for (int i = 0; i < spawnerCount; i++)
	    {
	        metaTypes[i] = MetaType.Spawner;
	    }

	    for (int i = spawnerCount; i < metaTypes.Length; i++)
	    {
	        metaTypes[i] = MetaType.Waypoint;
	    }

        metaTypes.Shuffle();

	    for (int i = 0; i < metaTypes.Length; i++)
	    {
	        MetaType metaType = metaTypes[i];
	        metaPoints[i].CreateMeta(metaType);
	    }
	}

    private bool CanBeCreated(MetaType type)
    {
        bool canBeCreated = false;

        switch (type)
        {
            case MetaType.Spawner:
                if (spawnerCount > 0)
                {
                    canBeCreated = true;
                    spawnerCount--;
                }
                break;

            case MetaType.Waypoint:
                if (waypointCount > 0)
                {
                    canBeCreated = true;
                    waypointCount--;
                }
                break;
        }

        return canBeCreated;
    }
}
