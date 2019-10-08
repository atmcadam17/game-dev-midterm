using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specialTalk : MonoBehaviour
{
    public List<string> dialogue;
    public bool friendly;

    private int talkPhase;

    private lonedogMove move;
    private dogFriend follow;

    public GameObject talkSystem;
    public Text text;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    
    void Start()
    {
        friendly = false;
        move = GameObject.Find("lone dog").GetComponent<lonedogMove>();
        follow = GameObject.Find("lone dog").GetComponent<dogFriend>();
        talkPhase = 0;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "player")
        {
            if (Input.GetKeyDown(KeyCode.Return) && follow.dogFollow == false)
            {
                talkSystem.SetActive(true);
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
                    talkPhase++;
                }
                text.text = dialogue[1];
            } else if (talkPhase == 2)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    talkPhase++;
                }
                text.text = dialogue[2];
            } else if (talkPhase == 3)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    talkPhase++;
                }
                text.text = dialogue[3];
            } else if (talkPhase == 4)
            {
                move.movement = true;
                talkPhase = 0;
                talkSystem.SetActive(false);
            }
        }

        if (other.name == "treat")
        {
            follow.dogFollow = true;
            move.movement = false;
        }
    }
}
