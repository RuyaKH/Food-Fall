using Random = UnityEngine.Random; //differntiating from UnityEngine.Random and System.Random
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class FoodSpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefab; //all different type of food prefabs set in unity
    public Vector2 secondsBetweenSpawnsMinMax; //vector2 that sets time between spawns which changes based on difficulty 
    float nextSpawnTime; //time until next spawn
    int randomInt; //random number for instantiating random foods

    Vector2 screenHalfSizeWorldUnits; //screen size to make sure foods dont spawn out of screen

    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize); //getting screen resolution 
        if (Settings.bEasy == true) //setting different seconds between spawn based on the setttings boolean (the difficulty of the game)
        {
            secondsBetweenSpawnsMinMax.x = 0.6f;
            secondsBetweenSpawnsMinMax.y = 1f;
        }
        else if (Settings.bMedium == true)
        {
            secondsBetweenSpawnsMinMax.x = 0.4f;
            secondsBetweenSpawnsMinMax.y = 1f;
        }
        else if (Settings.bHard == true)
        {
            secondsBetweenSpawnsMinMax.x = 0.2f;
            secondsBetweenSpawnsMinMax.y = 1f;
        }
        else
        {
            secondsBetweenSpawnsMinMax.x = 0.6f;
            secondsBetweenSpawnsMinMax.y = 1f;
        }
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime) //if time passed since level has loaded is more than the next spawn time then set spawn time and spawn positions and random food to instantiate
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent()); //math to work out seconds between spawns
            //print(secondsBetweenSpawns);
            nextSpawnTime = Time.timeSinceLevelLoad + secondsBetweenSpawns; //work out the next spawn time
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y); //position of the food that will be spawned
            randomInt = Random.Range(0, foodPrefab.Length); //random number from 0 to amount of food prefabs there are
            Instantiate(foodPrefab[randomInt], spawnPosition, Quaternion.identity); //instabtiate the random food prefab to the game
        }
    }
}