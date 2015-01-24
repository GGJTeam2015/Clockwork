using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Backpack to hold items
public class Backpack : MonoBehaviour{

	private List<Item> thePack = new List<Item>(); // The container

    public List<Item> getItems() { return thePack; } 
    public int getItemNum() { return thePack.Count; } // Number of items
    
    public void destroyItem(int idx) { thePack.RemoveAt(idx); } // Remove an item at index from container

    public void removeItem(string itemName)
    {
        thePack.Find(x => x.name == itemName).removeItem();

        if (thePack.Find(x => x.name == itemName).getCount() <= 0)
        {
            destroyItem(thePack.FindIndex(x => x.name == itemName));
        }
    } // Decrement the count and if 0 destroy it

    public bool hasItem(string itemName)
    {
        if (thePack.Exists(x => x.name == itemName))
        { return true; }
        else
        { return false; }
    }

    public void addItem(Item item) {
        if (hasItem(item.name))
        {
            thePack.Find(x => x.name == item.name).addItem();
        }

        else
        {
            thePack.Add(item);
        }
    } // Add an item to container. If already exist, increase count else add it

	public int getSpacecraftItemNum()
	{
		int count = 0;
		foreach(Item it in thePack)
		{
			if(it.GetType() == typeof(SpacecraftItem))
			{ count ++; }
		}
		return count;
	} // How many space craft items
}
