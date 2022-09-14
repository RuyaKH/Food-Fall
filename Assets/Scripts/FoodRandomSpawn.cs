using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class FoodRandomSpawn : MonoBehaviour
{
    private CountLife cl; //get script count life
    private CountScore cs; //get script count score 
    public static Vector2 speedMinMax; //max and min of the speed to set
    float speed; //speed of falling food
    float visibleHeightThreshold; //variable so food don't go off screen
    private AudioSource goodSound; //audio source for good food effect
    private AudioSource badSound; //audio source for bad food effect

    void Start()
    {
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y; //make sure that food does not go off the screen and is visible
        cl = FindObjectOfType<CountLife>(); //find game object with count life script
        cs = FindObjectOfType<CountScore>(); //find game object with count score script
        GameObject GoodSound = GameObject.Find("GoodSound"); //find game object called GoodSound on unity
        GameObject BadSound = GameObject.Find("BadSound"); //find game object called BadSound on unity
        goodSound = GoodSound.GetComponent<AudioSource>(); //get component of audio source in GoodSound and set it to goodSound
        badSound = BadSound.GetComponent<AudioSource>(); //get component of audio source in BadSound and set it to badSound

        if (Settings.bEasy == true) //settings based on difficulty which have different speed settings based on bools in settings script
        {
            speedMinMax.x = 6;
            speedMinMax.y = 9;
        }
        else if (Settings.bMedium == true)
        {
            speedMinMax.x = 7;
            speedMinMax.y = 11;
        }
        else if (Settings.bHard == true)
        {
            speedMinMax.x = 8;
            speedMinMax.y = 13;
        }
        else
        {
            speedMinMax.x = 6;
            speedMinMax.y = 9;
        }
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent()); //work out the speed with math based on the difficulty set
    }

    void Update() 
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime); //move the food prefab so that it falls down the screen based on set speed and deltaTime

        if (transform.position.y < visibleHeightThreshold) //if the food has gone past the edge of the screen
        {
            if (gameObject.tag == "GoodFood") //if the tag on the game object this script is attached to is GoodFood
            {
                cl.UpdateLifeValue(1); //update the life value by 1 (which loses a life)
                badSound.Play(); //play the bad sound effect
                Destroy(gameObject); //destroy the game object
            }
            else if (gameObject.tag == "BadFood") //if the tag on the game object this script is attached to is BadFood
            {
                cs.UpdateScoreValue(1); //update the score value by 1 (gain a point)
                goodSound.Play(); //play the good sound effect
                Destroy(gameObject); //destroy the game object
            }
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider) //if the food collides with another object
    {
        if (triggerCollider.tag == "Player") //if that object it collides with is tagged as Player
        {
            Debug.Log("Collision"); //debug the collision on console
            Destroy(gameObject); //destroy the game object
        }
    }
}
