using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIhealthControl : MonoBehaviour {

    public GameObject player; // Different for f1 and f2
    public bool isForP1 = true;

    private Image img;
    private Properties prop;

	// Use this for initialization
	void Start () {

        img = GetComponent<Image>();
        prop = player.GetComponent<PlayerProperties>();
	
	}
	
	// Update is called once per frame
	void Update () {

        img.fillAmount =  (0.0f+ prop.getHealth()) /  (0.0f + prop.getMaxHealth());
       
	}
}
