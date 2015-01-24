using UnityEngine;
using System.Collections;
using Assets.Scripts;


// Item that will be stored in the backpack
public class Item : MonoBehaviour{

    // Private fields
    public string name;
    public int count;

    // Getters
    public string getName() { return name; }
    public int getCount() { return count; }

    // Operations
    public int removeItem() { count--; return count; }
    public int addItem() { count++; return count; }

}
