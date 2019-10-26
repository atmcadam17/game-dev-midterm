using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specialTreatTalk : MonoBehaviour
{
    private bool playerCarry;
    
    public GameObject talkSystem;
    public Text text;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public List<string> dialogue;
    private int talkPhase;
    private lonedogMove move;
    
    private GameObject treat;
    private player playermove;

    private bool scoreUpdate;

    public float invoke;
    public GameObject thisDog;
    private bool talking2me;
    private bool talkingToSomeoneElse;

    public GameObject friendlyTime;
    public GameObject model;

    private bool newDogSpawn;
    
    void Start()
    {
        newDogSpawn = false;
        talking2me = false;
        invoke = .06f;
        scoreUpdate = false;
        playerCarry = false;
        talkPhase = 0;
        treat = GameObject.Find("treat");
        playermove = GameObject.Find("player").GetComponent<player>();
    }

    void Update()
    {
        playerCarry = GameObject.Find("player").GetComponent<player>().carrying;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Equals("player") && playerCarry && talkPhase == 0)
        {
            treat = GameObject.FindGameObjectWithTag("treat");
            talkSystem.SetActive(true);
            transform.parent.GetComponent<lonedogMove>().movement = false;
            playermove.movelocked = true;
            text.text = dialogue[0];
            answer1.text = "";
            answer2.text = "";
            answer3.text = "";
            destroyTreat();
        } else if (talkPhase == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Invoke(nameof(plusPhase), invoke);
            }
            
            text.text = dialogue[1];
        }
        
        if (talkPhase == 2)
        {
            var scoreMan = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            
            if (!scoreUpdate)
            {
                scoreMan.addScore(thisDog);
                scoreMan.lessDogsLeft();
                scoreUpdate = true;
            }
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Invoke(nameof(plusPhase), invoke);
            }
            
            text.text = dialogue[2];
        }
        
        if (talkPhase == 3)
        {
            text.text = "";
            answer1.text = "";
            answer2.text = "";
            answer3.text = "";
            transform.parent.gameObject.GetComponent<dogFriend>().dogFollow = true;
            playermove.movelocked = false;
            talkSystem.SetActive(false);
            if (!newDogSpawn)
            {
                newdog();
                newDogSpawn = true;
            }
        }
    }

    void newdog()
    {
        var newfriend = Instantiate(friendlyTime);
        newfriend.transform.position = this.transform.position;
        Destroy(model.gameObject);
        Destroy(this.gameObject);
    }


    void destroyTreat()
    {
        Destroy(treat);
        talkPhase = 1;
        playermove.carrying = false;
    }
    
    void plusPhase()
    {
        if (!IsInvoking())
        {
            talkPhase++;
        }
    }
}
