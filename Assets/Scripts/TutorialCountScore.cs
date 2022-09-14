using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TutorialCountScore : MonoBehaviour {

	public Text scoreText;
	public int scoreValue;

	// Use this for initialization
	void Start () {
        //Set the score to zero
        scoreValue = 0;
        GameObject score = GameObject.Find("PlayerScoreNum");
        scoreText = score.GetComponent<Text>();
        //DontDestroyOnLoad(gameObject);
        Debug.Log(gameObject.name + " start");
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Alter the score
    public void UpdateScoreValue(int scoreUpdate)
    {
        //Update the score
        scoreValue += scoreUpdate;

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
