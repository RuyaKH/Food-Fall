using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CountScore : MonoBehaviour {

	public Text scoreText; //score text in game
	public int scoreValue; //actual score value

	// Use this for initialization
	void Start () {
        scoreValue = 0; //set score to 0
        GameObject score = GameObject.Find("PlayerScoreNum"); //find game object for score value to go
        scoreText = score.GetComponent<Text>(); //convert score to text
        DontDestroyOnLoad(gameObject); //do not destroy the score game object so value can be passed to other scenes
        UpdateScoreText(); //update score function
    }

    private void OnEnable() //check if scene is loaded 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() //check is scene is loaded
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //if game over scene is loaded then update the score value and set it to game object text for game over scene, if menu loaded then destroy score
    {
        if (String.Equals(scene.name, "GameOver", StringComparison.OrdinalIgnoreCase)) //if game over loaded
        {
            GameObject score = GameObject.Find("PlayerScoreNum"); //find game object called PlayerScoreNum so it can be updated with the score value
            scoreText = score.GetComponent<Text>(); //get the text for score
            scoreText.text = scoreValue.ToString(); //convert int to string for text
        }

        if (String.Equals(scene.name, "Menu", StringComparison.OrdinalIgnoreCase)) //if menu is loaded then destroy the game object so the score is restarted
        {
            Destroy(gameObject);
        }
    }

    //Alter the score
    public void UpdateScoreValue(int scoreUpdate)
    {
        //Update the score
        scoreValue += scoreUpdate;
        //hst.AddHighScoreEntry(scoreValue, "TRY");

        //Update the text of the score in the UI
        UpdateScoreText();
    }

    //Update the score in the game
    void UpdateScoreText()
    {
        scoreText.text = "" + scoreValue;
    }

    //Reset score to zero
    void ResetScore()
    {
        scoreValue = 0;
        UpdateScoreText();
    }
}
