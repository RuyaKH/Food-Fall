using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialScriptCake : MonoBehaviour
{
    public GameObject endTutorial; //image canvas for end of tutorial
    public GameObject howToPlayText; //how to play text
    float visibleHeightThreshold; //screen size

    void Start()
    {
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y; //work out screen size
        endTutorial.SetActive(false); //canvas image set to false
    }

    void Update()
    {
        if (transform.position.y < visibleHeightThreshold) //if game object script is attached to goes past end of screen, go to function Show()
        {
            Show();
        }
    }

    void Show() //if called, destroy game object, canvas image end tutorial true and text to false
    {
        Destroy(gameObject);
        endTutorial.SetActive(true);
        howToPlayText.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider) //if game object collides with player then go to function Show()
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Collision");
            Show();
        }
    }
}
