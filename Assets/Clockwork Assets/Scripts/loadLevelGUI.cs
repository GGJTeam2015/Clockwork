using UnityEngine;
using System.Collections;

public class loadLevelGUI : MonoBehaviour
{
    private static loadLevelGUI instance = null;

    public static loadLevelGUI Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<loadLevelGUI>();
            }

            return instance;
        }
    }

    // Use this for initialization
	public void newGame()
	{
		Application.LoadLevel("Level2");
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

    public void win()
    {
        Application.LoadLevel("win");
    }

    public void loose()
    {
        Application.LoadLevel("loose");
    }

    public void loadLevelWithDelay(string func, float seconds)
    {
        Invoke(func, seconds);
    }
}
