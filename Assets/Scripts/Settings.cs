using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public Button easy; //buttons for options menu
    public Button medium;
    public Button hard;

    public static bool bEasy = false; //global bools to be changed within other scripts
    public static bool bMedium = false;
    public static bool bHard = false;

    public AudioMixer audioMixer; //audio mixer to control sound 

    void Start()
    { 
        //get buttons from unity
        easy = easy.GetComponent<Button>();
        medium = medium.GetComponent<Button>();
        hard = hard.GetComponent<Button>();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume); //setting the master volume on mixer using slider
    }

    public void Easy() //setting easy bool to true when button pressed
    {
        bEasy = true;
        Debug.Log("Easy");
    }

    public void Medium() //setting medium bool to true when button pressed
    {
        bMedium = true;
        Debug.Log("Medium");
    }

    public void Hard() //setting hard bool to true when button pressed
    {
        bHard = true;
        Debug.Log("Hard");
    }
}
