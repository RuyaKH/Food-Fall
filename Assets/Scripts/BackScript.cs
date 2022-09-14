using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackScript : MonoBehaviour
{
    public Button back; //public button for back

    void Start()
    {
        back = back.GetComponent<Button>(); //get component in unity
    }

    public void Back() //if button pressed load the menu scene
    {
        SceneManager.LoadScene("Menu");
    }
}
