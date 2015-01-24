using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpacecraftItemControl : MonoBehaviour {

    // Singleton Instance
    private static SpacecraftItemControl inst = null;

    // Generated Goals
    public List<int> goalsP1 = new List<int>();
    public List<int> goalsP2 = new List<int>();

    // Object prefabs
    public List<GameObject> itemPrefabs = new List<GameObject>(5);
    public List<string> itemNames = new List<string>(5); // Name in the same order as itemPrefabs
    public float prefabDropProb = 0.1f;

    // Generation parameters
    public int totalNumOfObj = 10;

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

        genGoals();
        
    }

    private void initGoals()
    {
        int numItems = itemPrefabs.Count;
        for (int i = 0; i != numItems; i++)
            {goalsP1.Add(0); goalsP2.Add(0);}
    }

    private void genGoals()
    {
        initGoals();

        // For P1
        while (sumUp(goalsP1) < totalNumOfObj)
        {
            int r = Random.Range(0, totalNumOfObj - sumUp(goalsP1) + 1);
            int idx = Random.Range(0, itemPrefabs.Count);
            goalsP1[idx] += r;
        }

        // For P2
        while (sumUp(goalsP2) < totalNumOfObj)
        {
            int r = Random.Range(0, totalNumOfObj - sumUp(goalsP2) + 1);
            int idx = Random.Range(0, itemPrefabs.Count);
            goalsP2[idx] += r;
        }
        
    }

    private int sumUp(List<int> list)
    {
        int count = 0;
        foreach (int i in list)
        {
            count += i;
        }
        return count;
    }


}
