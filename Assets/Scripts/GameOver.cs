using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour
{
    //buttons to play again and exit game
    public Button playAgainButton;
    public Button endGameButton;

    void Start()
    {
        //getting the components of the buttons
        playAgainButton = playAgainButton.GetComponent<Button>();
        endGameButton = endGameButton.GetComponent<Button>();
    }

    public void StartLevel() //if play again pressed load the menu scene
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame() //if exit game pressed the game is closed
    {
        Application.Quit();
    }
}
