using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreUpdate : MonoBehaviour
{
    public int dogsLeft;
    private Text scoreDisplay;
    
    void Start()
    {
        dogsLeft = 3;
        scoreDisplay = GetComponent<Text>();
        
        scoreDisplay.text = "Dogs to Collect: " + dogsLeft;
    }

    void Update()
    {
        if (dogsLeft <= 0)
        {
            SceneManager.LoadScene("end screen");
        }
    }

    public void downDog()
    {
        dogsLeft--;
        scoreDisplay.text = "Dogs to Collect: " + dogsLeft;
    }
}
