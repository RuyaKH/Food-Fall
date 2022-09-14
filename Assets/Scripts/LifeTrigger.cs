using UnityEngine;
using System.Collections;

public class LifeTrigger : MonoBehaviour
{
    private CountLife cl; //get script CountLife

    void Start()
    {
        cl = FindObjectOfType<CountLife>(); //find game object with CountLife attached
    }

    void OnTriggerEnter2D(Collider2D LoseLife) //if game object with tag bad food is collided with player then update life value by 1 to lose life
    {
        Debug.Log("LoseLife");
        Debug.Log(LoseLife.tag);

        if (LoseLife.tag == "BadFood")
        {
            cl.UpdateLifeValue(1);
            Debug.Log(gameObject.name);
        }

    }
}