using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorial; //game object canvas image tutorial
    float visibleHeightThreshold; //screen size 
    private TutorialCountLife cl; //get script 
    private TutorialCountScore cs; //get script
    float speed = 0; //set speed

    void Start()
    {
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y; //setting screensize 
        cl = FindObjectOfType<TutorialCountLife>(); //find game object with TutorialCountLife script
        cs = FindObjectOfType<TutorialCountScore>(); //find game object with TutrorialCountScore script
    }

    void Update()
    {
        if (tutorial.activeSelf == true) //if game object canvas image is true then set speed to 0
        {
            speed = 0;
        }
        else if (tutorial.activeSelf == false) //if false set to 7
        {
            speed = 7;
        }

        transform.Translate(Vector3.down * speed * Time.deltaTime); //transform game object to move downwards based on speed and time 

        if (transform.position.y < visibleHeightThreshold) // if game object has gone passed the edge of the screen
        {
            if (gameObject.tag == "GoodFood") // if game object is tagged as good food then update life value by 1 and destroy it
            {
                cl.UpdateLifeValue(1);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "BadFood") // if game object is tagged as bad food then update score value by 1 and destroy it
            {
                cs.UpdateScoreValue(1);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Cake") // if game object is tagged as cake update score value but do not destroy it because it is needed for other script
            {
                cs.UpdateScoreValue(1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) // if game object collides with player with tag either good food or bad food then destroy it
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Collision");
            if (gameObject.tag == "GoodFood" || gameObject.tag == "BadFood")
            {
                Destroy(gameObject);
            }
        }
    }
}
