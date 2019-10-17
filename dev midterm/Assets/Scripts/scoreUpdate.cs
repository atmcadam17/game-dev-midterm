using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreUpdate : MonoBehaviour
{
    public int dogsLeft;
    // private Text scoreDisplay;
    
    void Start()
    {
        dogsLeft = 3;
    }

    void Update()
    {
        if (dogsLeft <= 0)
        {
            SceneManager.LoadScene("end screen");
        }
        
        // scoreDisplay.text = "Dogs to Collect: " + dogsLeft;
    }

    public void downDog()
    {
        dogsLeft--;
        // scoreDisplay.text = "Dogs to Collect: " + dogsLeft;
    }
}
