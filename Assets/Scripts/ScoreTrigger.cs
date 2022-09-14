using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour
{
	private CountScore cs; //get the script CountScore

    void Start()
    {
        cs = FindObjectOfType<CountScore>(); //find game object with script CountScore attached
    }

	void OnTriggerEnter2D (Collider2D GoodFoodCheck){ //if game object with tag good food is collided with player update score by 1
		Debug.Log ("Good food collided");
		Debug.Log (GoodFoodCheck.tag);

        if (GoodFoodCheck.tag == "GoodFood")
        {
            cs.UpdateScoreValue(1);                
            Debug.Log(gameObject.name);
        }
	
	}
}
