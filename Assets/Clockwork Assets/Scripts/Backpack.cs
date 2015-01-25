using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Backpack to hold items
public class Backpack : MonoBehaviour{

    public bool isP1 = true; // 1:This Backpack Belongs to P1  0:This Backpack Belongs to P2

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

    public int getItemNum(string itemName)
    {
        int count = 0;
        foreach (Item it in thePack)
        {
            if (it.name == itemName)
            {
                count += it.count;
            }
        }
        return count;
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

        
        // Check if win?!
        checkWin();

	} // Add an item to container. If already exist, increase count else add it

    private void checkWin()
    {
        // Check if one wins!
        if (isP1)
        {
            if (checkEndGameP1())
            {
                Debug.Log("P1 WINS!!!!");
            }
        }

        else
        {
            if (checkEndGameP2())
            {
                Debug.Log("P2 WINS!!!!");
            }
        }
    }

    private bool checkEndGameP2()
    {
        List<string> names = SpacecraftItemControl.Inst.itemNames;
        List<int> goalP1 = SpacecraftItemControl.Inst.goalsP1;
        List<int> goalP2 = SpacecraftItemControl.Inst.goalsP2;


        // For P2
        bool isP2Win = true;
        for (int i = 0; i != names.Count; i++)
        {
            if (getItemNum(names[i]) < goalP2[i])
            {
                isP2Win = false;
            }
        }

        return isP2Win;
    }

    private bool checkEndGameP1()
    {
        List<string> names = SpacecraftItemControl.Inst.itemNames;
        List<int> goalP1 = SpacecraftItemControl.Inst.goalsP1;
        List<int> goalP2 = SpacecraftItemControl.Inst.goalsP2;

        // For P1
        bool isP1Win = true;
        for (int i = 0; i != names.Count; i++)
        {
            if (getItemNum(names[i]) < goalP1[i])
            {
                isP1Win = false;
            }
        }

        return isP1Win;
    }

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

	// Check if player grabbed a spacecraft item
	void OnCollisionEnter(Collision coll)
	{
		// Dont get mad! :P
		// If it is a spacecraft item
		if (coll.gameObject.GetComponent<SpacecraftItem>() != null)
		{
			// Add it to the backpack
			this.GetComponent<Backpack>().addItem(coll.gameObject.GetComponent<SpacecraftItem>());

			// Destroy it
			Destroy(coll.gameObject);
		}
	}
}
