using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject _normalEggs;
    public GameObject _normalDiana;
    public GameObject _normalPartytime;
    public GameObject _normalEdward;
    
    private bool eggs;
    private bool diana;
    private bool edward;
    private bool partytime;

    public int dogsLeft;

    public Text dogsLeftText;
    
    void Start()
    {
        eggs = false;
        diana = false;
        partytime = false;
        dogsLeft = 4;
    }

    
    void Update()
    {
    }

    public void addScore(GameObject dog)
    {
        var manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        manager.score++;

        if (dog == _normalDiana)
        {
            diana = true;
            manager._gotDiana = true;
        } else if (dog == _normalEggs)
        {
            eggs = true;
            manager._gotEggs = true;
        } else if (dog == _normalPartytime)
        {
            partytime = true;
            manager._gotPartytime = true;
        } else if (dog == _normalEdward)
        {
            edward = true;
            manager._gotEdward = true;
        }
    }

    public void lessDogsLeft()
    {
        dogsLeft--;
        dogsLeftText.text = "Dogs Left: " + dogsLeft;
        
        if (dogsLeft <= 0)
        {
            Invoke("endGame", 3);
        }
    }

    public void endGame()
    {
        SceneManager.LoadScene("end screen");
    }
}
