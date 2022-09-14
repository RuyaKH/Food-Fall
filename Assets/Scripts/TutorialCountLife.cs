using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialCountLife : MonoBehaviour
{
    public Text lifeText;
    [SerializeField]
    public int lifeValue;
    [SerializeField]
    private int loseScore;
    public int scoreValue;

    // Use this for initialization
    void Start()
    {
        //Set the life to 5
        lifeValue = 8;
        UpdateLifeText();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Alter the score
    public void UpdateLifeValue(int lifeUpdate)
    {
        //Update the score
        lifeValue -= lifeUpdate;

        //Update the text of the score in the UI
        UpdateLifeText();
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
