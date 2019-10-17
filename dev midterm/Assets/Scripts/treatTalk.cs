using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class treatTalk : MonoBehaviour
{
    // lone dog gets a special script but the others get 1 customizable one that makes it say smth
    // one treat per dog - special text for already given treat like "he looks full"
    // maybe there's a funny interaction if you give it to the person
    // like "i don't want this" and maybe some1 takes it

    private bool playerCarry;
    public bool talking;
    
    public GameObject talkSystem;
    public Text text;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public List<string> dialogue;
    private int talkPhase;
    private lonedogMove move;

    private bool talked;

    private GameObject treat;
    private talkBox talkboxscript;
    private player playermove;
    
    void Start()
    {
        talked = false;
        playerCarry = false;
        talkPhase = 0;
        treat = GameObject.Find("treat");
        talking = false;
        talkboxscript = this.GetComponent<talkBox>();
        playermove = GameObject.Find("player").GetComponent<player>();
    }

    void Update()
    {
        playerCarry = GameObject.Find("player").GetComponent<player>().carrying;
    }

    private void OnTriggerStay(Collider other)
    {
        treat = GameObject.FindGameObjectWithTag("treat");
        if (other.name.Equals("player") && playerCarry && !talked && talkPhase == 0)
        {
            Destroy(GameObject.Find("treat"));
            playerCarry = false;
            playermove.movelocked = true;
            talkSystem.SetActive(true);
            answer1.text = "";
            answer2.text = "";
            answer3.text = "";
            talkPhase++;
        } else if (talkPhase == 1)
        {
            answer1.text = "";
            answer2.text = "";
            answer3.text = "";
            text.text = dialogue[1];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                talkPhase++;
            }
            text.text = dialogue[1];
        } else if (talkPhase == 2)
        {
            playermove.movelocked = false;
            talkSystem.SetActive(false);
            talked = true;
            
            Invoke(nameof(destroyTreat), .04f);
        }
    }


    void destroyTreat()
    {
        Destroy(treat);
        talkPhase = -1;
        playermove.carrying = false;
    }
}
