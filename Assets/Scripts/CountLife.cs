using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountLife : MonoBehaviour
{
    public Text lifeText; //text for the life value
    [SerializeField]
    public int lifeValue; //actual int life value 
    [SerializeField]
    private int loseScore; //lose score which is always 0
    public int scoreValue; //score value to be updated for game over scene

    // Use this for initialization
    void Start()
    {
        //Set the life to 5
        lifeValue = 8;
        UpdateLifeText();

    }

    //Alter the score
    public void UpdateLifeValue(int lifeUpdate)
    {
        //Update the score
        lifeValue -= lifeUpdate;

        //Update the text of the score in the UI
        UpdateLifeText();

        //Check if player has lost lives

        if (loseScore >= lifeValue)
        {
            //Open the game over scene
            PlayerPrefs.SetInt("Score", scoreValue);
            SceneManager.LoadScene("GameOver");
        }
    }

    //Update the score in the game
    void UpdateLifeText()
    {
        lifeText.text = "" + lifeValue;
    }

    //Reset score to zero
    void ResetLife()
    {
        lifeValue = 8;
        UpdateLifeText();
    }


}
