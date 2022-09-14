using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;  //rididbody of the player
    private float moveSpeed; //float that takes in the variable the players speed

    public AudioSource goodSound; //audiosource object for sound effect when player collides with good foods
    public AudioSource badSound; //audiosource object for sound effect when player collides with bad foods

    public Animator playerAnimator; //animator for the player, allowing for different animations to the basket when events occur
    public static bool CaughtGoodFood = false; //bool variable that can be used globally amongst scripts
    public static bool CaughtBadFood = false; // ^^
    public static bool MissGoodFood = false; // ^^

    float visibleHeightThreshold; //float for screen width and height 
    float animationTime = 0.75f; //float for animation wait time

    //using for initialisation
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //get the rididbody from game object which is the player
        moveSpeed = -6f; //the speed that player moves at
        //playerAnimator = GetComponent<Animator>();
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y; //working out the screen width and height 

    }

    //Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0) //getting touch input from user to the screen
        {
            Touch touch = Input.GetTouch(0); 

            switch (touch.phase) //switch statement that occurs when user touches the screen
            {
                case TouchPhase.Began:
                    if (touch.position.x < Screen.width / 2) rb.velocity = new Vector2(moveSpeed, 0f); //if user touches left side of the screen, player moves toward left
                    if (touch.position.x > Screen.width / 2) rb.velocity = new Vector2(-moveSpeed, 0f); //if user touches right side of the screen, player moves right
                    break;
                case TouchPhase.Ended: //user no longer touching screen
                    rb.velocity = new Vector2(0f, 0f); //player stays still
                    break;
            }
        }
    }

    IEnumerator Wait(string foodS, bool foodB, float animationTime)  //IEnumarator function to control WaitForSeconds and use yield return, needed for animation, 
    {
        foodB = true; //get static boolean and change to true
        playerAnimator.SetBool(foodS, foodB); //set animation to set string, same name as in animator in unity and static boolean setting true value for animation to change 
        yield return new WaitForSeconds(animationTime); //the function and animation stops and waits for 0.75f seconds
        foodB = false; //sets static boolean to false
        playerAnimator.SetBool(foodS, foodB); //set animation to false and goes back to default
    }

    void OnTriggerEnter2D(Collider2D collide) //trigger function when player collides with a gameobject
    {
        if (collide.tag == "GoodFood") //if game object is a good food then start the CaughtGoodFood animation and play good food audio effect
        {
            StartCoroutine(Wait("CaughtGoodFood", CaughtGoodFood, animationTime));
            goodSound.Play();
        }
        if (collide.tag == "BadFood") //if game object is a bad food then start the CaughtBadFood animation and play bad food audio effect
        {
            StartCoroutine(Wait("CaughtBadFood", CaughtBadFood, animationTime));
            badSound.Play();
        }
    }
}
