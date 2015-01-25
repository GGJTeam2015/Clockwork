using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class controlGUI : MonoBehaviour {

    public GameObject player; // Different for f1 and f2
    public bool isForP1 = true;

    private Backpack bpack;
    private Text text;
    private List<string> names;
    private List<int> goals;

	// Use this for initialization
	void Start () {

        
        names = SpacecraftItemControl.Inst.itemNames;
        text = GetComponent<Text>();
        bpack = player.GetComponent<Backpack>();

        if (isForP1)
        {
            goals = SpacecraftItemControl.Inst.goalsP1;
        }

        else
        {
            goals = SpacecraftItemControl.Inst.goalsP2;
        }

	}
	
	// Update is called once per frame
	void Update () {

        string te = "";

        int i = 0;
        foreach (string str in names)
        {
            te += str + " " + bpack.getItemNum(str) + "/" + goals[i];
            i++;
        }

        text.text = te;
	
	}
}
