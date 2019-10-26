using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specialTalk : MonoBehaviour
{
    public List<string> dialogue;

    private int talkPhase;

    private lonedogMove move;
    private dogFriend follow;

    public GameObject talkSystem;
    public Text text;
    public Text answer1;
    public Text answer2;
    public Text answer3;

    public bool inRange;

    private player playermove;
    private bool talkingToSomeoneElse;
    private bool talkingToMe;
    
    void Start()
    {
        talkingToMe = false;
        move = GameObject.Find("partytime").GetComponent<lonedogMove>();
        follow = GameObject.Find("partytime").GetComponent<dogFriend>();
        talkPhase = 0;
        inRange = false;
        playermove = GameObject.Find("player").GetComponent<player>();
        talkingToSomeoneElse = false;
    }

    void Update()
    {
        if (talkSystem.activeSelf && !talkingToMe)
        {
            talkingToSomeoneElse = true;
        }
        else
        {
            talkingToSomeoneElse = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "player")
        {
            if (Input.GetKeyDown(KeyCode.Return) && follow.dogFollow == false && !talkingToSomeoneElse)
            {
                talkingToMe = true;
                talkSystem.SetActive(true);
                playermove.movelocked = true;
                move.movement = false;
                answer1.text = "";
                answer2.text = "";
                answer3.text = "";

                text.text = dialogue[0];
                talkPhase++;
            } else if (talkPhase == 1)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Invoke("addPhase", .2f);
                }
                text.text = dialogue[1];
            } else if (talkPhase == 2)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Invoke("addPhase", .2f);
                }
                text.text = dialogue[2];
            } else if (talkPhase == 3)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Invoke("addPhase", .2f);
                }
                text.text = dialogue[3];
            } else if (talkPhase == 4)
            {
                move.movement = true;
                talkingToMe = true;
                talkPhase = 0;
                talkSystem.SetActive(false);
                playermove.movelocked = false;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("player"))
        {
            inRange = false;
        }
    }
    
    void addPhase()
    {
        if (!IsInvoking())
        {
            talkPhase++;
        }
    }
}
