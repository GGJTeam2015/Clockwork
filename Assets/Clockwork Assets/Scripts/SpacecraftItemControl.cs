using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpacecraftItemControl : MonoBehaviour {

    // Singleton Instance
    private static SpacecraftItemControl inst = null;

    // Object prefabs
    public List<GameObject> itemPrefabs = new List<GameObject>(5);
    public float prefabDropProb = 0.1f;

    // Get a prefab
    public GameObject giveMeAnItem()
    {
        // Drop?
        if (Random.Range(0.0f, 1.0f) < prefabDropProb)
        {
            // Drop which?
            int idx = Random.Range(0, itemPrefabs.Count);
            return itemPrefabs[idx];
        }

        else
        {
            return null;
        }
    }

    // Getter
    public static SpacecraftItemControl Inst { get { return inst; } }
    void Awake()
    {
        if (inst == null)
        { inst = this; }
    }


}
