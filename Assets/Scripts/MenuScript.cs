using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    //various buttons for menu
	public Button playButton;
    //public Button highscoreButton;  could not get high score to work, button still here for future updates
	public Button optionsButton;
    public Button howToPlayButton;

    public AudioSource menuMusic; //audio source that gets the background music for the menu

	void Start () {
        //get components of the buttons
		playButton = playButton.GetComponent<Button> ();
		//highscoreButton = highscoreButton.GetComponent<Button> (); could not get high score to work, get component still here for future updates
		optionsButton = optionsButton.GetComponent<Button> ();
        howToPlayButton = howToPlayButton.GetComponent<Button>();
        menuMusic.Play();
	}

	public void PlayGame() { //if play game button pressed then load the scene game amd destroy the menu music 
		SceneManager.LoadScene("Game");
        Destroy(menuMusic);
	}

    //public void HighScore()  //could not get high score to work, button function still here for future updates
    //{
    //    SceneManager.LoadScene("HighScore");
    //}

    public void Options() //if options button pressed then load the scene options
    {
        SceneManager.LoadScene("Options");
    }

    public void HowToPlay() //if how to play button pressed then load the scene how to play
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
