using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Use this script for the Pause Menu UI buttons on the Pause Menu 
public class PauseMenu : MonoBehaviour
{
    //VARIABLES//

    //REFERENCES//
    public GameObject controlsMenu;
    private GameManager gm; 

    // Start is called before the first frame update
    void Start()
    {
        controlsMenu.SetActive(false);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Calls the GameManager's Pause() method to Resume the game if already paused.
    public void ResumeGame()
    {
        gm.PauseGame();
    }

    //Returns players back to the title screen (Quit in the Pause Menu)
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    //Opens the controls menu to remind players how to play the game (Controls in the Pause Menu)
    public void OpenControlsMenu()
    {
        controlsMenu.SetActive(true);
    }

    //Closes the controls menu and returns back to the normal pause menu (Quit in the Controls Menu)
    public void CloseControlsMenu()
    {
        controlsMenu.SetActive(false);
    }

    //Restarts the current level which the players are on (Restart Button)
    public void RestartCurLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
