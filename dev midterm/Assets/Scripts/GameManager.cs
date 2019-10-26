using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;
 
    public bool _gotEggs = false;
    public bool _gotDiana = false;
    public bool _gotEdward = false;
    public bool _gotPartytime = false;

    private GameObject _endEggs;
    private GameObject _endDiana;
    private GameObject _endPartytime;
    private GameObject _endEdward;

    public int score;
    private Text endText;

    private bool restart;

    private void Awake()
    {
        if (_gameManager == null)
        {
            _gameManager = this;
        } else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        restart = false;
    }

    void Update()
    {
        // set up end screen
        if (SceneManager.GetActiveScene().name == "end screen")
        {
            _endDiana = GameObject.Find("princess diana");
            _endEggs = GameObject.Find("mr. eggs");
            _endEdward = GameObject.Find("edward");
            _endPartytime = GameObject.Find("partytime");
        }
        else
        {
            _endDiana = null;
            _endEggs = null;
            _endEdward = null;
            _endPartytime = null;
        }
        
        if (SceneManager.GetActiveScene().name == "end screen" && !_gotEggs)
        {
            _endEggs.SetActive(false);
        }
        
        if (SceneManager.GetActiveScene().name == "end screen" && !_gotDiana)
        {
            _endDiana.SetActive(false);
        }
        
        if (SceneManager.GetActiveScene().name == "end screen" && !_gotEdward)
        {
            _endEdward.SetActive(false);
        }
        
        if (SceneManager.GetActiveScene().name == "end screen" && !_gotPartytime)
        {
            _endPartytime.SetActive(false);
        }
        
        
        
        // end screen text & restart
        if (SceneManager.GetActiveScene().name == "end screen")
        {
            endText = GameObject.Find("txt").GetComponent<Text>();
            endText.text = "you collected " + score + "/4 dogs!";

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("title");
                restart = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "title" && restart)
        {
            _gotDiana = false;
            _gotEdward = false;
            _gotEggs = false;
            _gotPartytime = false;
            score = 0;
            restart = false;
        }
    }
    
}
