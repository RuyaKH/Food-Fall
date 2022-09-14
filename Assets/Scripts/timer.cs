using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class timer : MonoBehaviour
{
    public Text timeGone; //text for amount of time passed
    private int gameTimerInt; //int for timer
    public float gameTimer = 0; //float for timer
    public bool gameTimerIsRunning = false; //bool to check if timer is running or not 

    void Start()
    {
        gameTimerIsRunning = true; //on start timer is running
        DontDestroyOnLoad(gameObject); //timer to not be destroyed and can be passed through scenes
        Debug.Log(gameObject.name + "Start"); //debug for timer
    }

    void Update()
    {
        if (gameTimerIsRunning) //if game timer running is true
        {
            if (gameTimer >= 0) //if timer is less than or equal to 0 then 
            {
                gameTimer += Time.deltaTime; //add time to the game timer
                gameTimerInt = Mathf.RoundToInt(gameTimer); //round game timer to int so it can be easily shown on game
            }
        }
    }

    private void OnEnable() //check if scene loaded
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() //check if scene loaded
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //if game over scene is loaded then find text object for timer to go
    {
        Debug.Log("loaded " + scene.name); //debug line
        if (String.Equals(scene.name, "GameOver", StringComparison.OrdinalIgnoreCase))
        {
            GameObject time = GameObject.Find("SurviveNum"); //find game object called SurviveNum
            timeGone = time.GetComponent<Text>(); //set time gone to text component
            timeGone.text = gameTimerInt.ToString() + " seconds"; //get gamer timer int to string and into text component
            Debug.Log("set score text to " + timeGone); //debug line
        }

        if (String.Equals(scene.name, "Menu", StringComparison.OrdinalIgnoreCase)) //if menu scene loaded destroy game object so timer is reset
        {
            Destroy(gameObject); 
        }
    }
}