using UnityEngine;
using System.Collections;
using Assets.Scripts;


// Item that will be stored in the backpack
public class Item : MonoBehaviour{

    // Public fields
    public string name;

    // Private fields
    public int count = 1;

    // Getters
    public string getName() { return name; }
    public int getCount() { return count; }

    // Operations
    public int removeItem() { count--; return count; }
    public int addItem() { count++; return count; }

}
