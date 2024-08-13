using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Use this script on the Title Screen to interact with the Menu Buttons
public class TitleScreen : MonoBehaviour
{
    //REFERENCES//
    public GameObject ControlsMenu; //Menu for displaying controls to players 
    public GameObject creditsPanel; //Menu for showing the credits of the game

    // Start is called before the first frame update
    void Start()
    {
        ControlsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Start the Game when clicking on the Start Button on the Title Screen 
    public void StartGame()
    {
        //When clicking START, load the Test Scene (temporary).
        SceneManager.LoadScene("Level1");
    }

    //Exits out of the game on click (in editor AND in builds).
    public void QuitGame()
    {
        //If you're in Play Mode and Click Quit (in-editor) 
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;

        //If you're quitting in a build, exit out of the Application.
        #endif
                Application.Quit();
    }

    //Opens up the Controls Panel to Indicate how to play the game. 
    public void OpenControlsPanel()
    {
        ControlsMenu.SetActive(true);
    }

    public void CloseControlsPanel()
    {
        ControlsMenu.SetActive(false);
    }
}
