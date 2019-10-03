using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreUpdate : MonoBehaviour
{
    public int score;
    private Text scoreDisplay;
    
    void Start()
    {
        score = 0;
        scoreDisplay = GetComponent<Text>();
    }

    void Update()
    {
        
    }
}
