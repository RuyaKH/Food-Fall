using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BackScriptTutorial : MonoBehaviour
{
    //script for how to play scene
    public Button back; //button to go back to main screen (off canvas)
    public GameObject tutorialPage; //tutorial page canvas image
    public GameObject howToPlayText; //text 

    void Start()
    {
        tutorialPage.SetActive(true); //on startup show tutorial canvas image
        howToPlayText.SetActive(false); //do not show text
        back = back.GetComponent<Button>(); //get component of back button in unity
    }

    public void Back() //if back button pressed, close the canvas and show the text
    {
        tutorialPage.SetActive(false); //close canvas
        howToPlayText.SetActive(true); //show text
    }
}
