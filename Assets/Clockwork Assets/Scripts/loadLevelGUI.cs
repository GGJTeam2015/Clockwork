using UnityEngine;
using System.Collections;

public class loadLevelGUI : MonoBehaviour {

	// Use this for initialization
	public void newGame()
	{
		Application.LoadLevel("Level1");
	}

	public void mainMenu()
	{
		Application.LoadLevel("MainMenu");
	}

	public void credits()
	{
		Application.LoadLevel("Credits");
	}

	public void exit()
	{
		Application.Quit();
	}
}
