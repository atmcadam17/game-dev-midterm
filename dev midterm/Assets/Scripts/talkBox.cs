using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkBox : MonoBehaviour
{
    public GameObject talkSystem;
    public GameObject dog;
    private player playerscript;

    private int favor;
    
    public string dialogue1;
    public string answer11;
    public string answer12;
    public string answer13;
    public int rightanswer1;

    
    public string dialogue2;
    public string answer21;
    public string answer22;
    public string answer23;
    public int rightanswer2;
    
    public Text dialogue;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    private int highlightedAnswer;

    public string successText;
    public string failText;

    public string alreadyTalkedText;
    
    private int talkPhase;
    private bool alreadyTalked;
    private bool talking;
    
    
    void Start()
    {
        talkSystem.SetActive(false);
        playerscript = GameObject.Find("player").GetComponent<player>();
        highlightedAnswer = 1;
        talkPhase = 0;
        alreadyTalked = false;
        talking = false;
    }

    void Update()
    {
        if (highlightedAnswer == 1)
        {
            answer1.color = new Color(0,0,0,1);
            answer2.color = new Color(0,0,0,.5f);
            answer3.color = new Color(0,0,0,.5f);
        } else if (highlightedAnswer == 2)
        {
            answer1.color = new Color(0,0,0,.5f);
            answer2.color = new Color(0,0,0,1);
            answer3.color = new Color(0,0,0,.5f);
        } else if (highlightedAnswer == 3)
        {
            answer1.color = new Color(0,0,0,.5f);
            answer2.color = new Color(0,0,0,.5f);
            answer3.color = new Color(0,0,0,1);
        }
        
        if (talkSystem.activeSelf)
        {
            if (highlightedAnswer > 1 && highlightedAnswer <= 3 && Input.GetKeyDown(KeyCode.UpArrow) || highlightedAnswer > 1 && highlightedAnswer <= 3 && Input.GetKeyDown(KeyCode.W))
            {
                highlightedAnswer -= 1;
            } else if (highlightedAnswer < 3 && highlightedAnswer >= 1 && Input.GetKeyUp(KeyCode.DownArrow) || highlightedAnswer < 3 && highlightedAnswer >= 1 && Input.GetKeyUp(KeyCode.S))
            {
                highlightedAnswer += 1;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Equals("player"))
        {
            if (talkPhase == 0 && Input.GetKeyDown(KeyCode.Return) && !alreadyTalked)
            {
                talkSystem.SetActive(true);
                playerscript.movelocked = true;
                talkPhase++;
            } else if (talkPhase == 1)
            {
                dialogue.text = dialogue1;
                answer1.text = answer11;
                answer2.text = answer12;
                answer3.text = answer13;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (highlightedAnswer == rightanswer1)
                    {
                        favor++;
                    }
                    talkPhase++;
                    highlightedAnswer = 1;
                    Debug.Log("favor: " + favor);
                }
            } else if (talkPhase == 2)
            {
                dialogue.text = dialogue2;
                answer1.text = answer21;
                answer2.text = answer22;
                answer3.text = answer23;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (highlightedAnswer == rightanswer2)
                    {
                        favor++;
                    }
                    talkPhase++;
                    highlightedAnswer = 1;
                    Debug.Log("favor: " + favor);
                }
            } else if (talkPhase == 3)
            {
                if (favor == 2)
                {
                    dialogue.text = successText;
                    answer1.text = "";
                    answer2.text = "";
                    answer3.text = "";
                    
                    dog.GetComponent<dogFriend>().dogFollow = true;
                }
                else
                {
                    dialogue.text = failText;
                    answer1.text = "";
                    answer2.text = "";
                    answer3.text = "";
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    playerscript.movelocked = false;
                    alreadyTalked = true;
                    talkSystem.SetActive(false);
                    talkPhase = 0;
                    highlightedAnswer = 1;
                }
            } else if (alreadyTalked && Input.GetKeyDown(KeyCode.Return))
            {
                talkSystem.SetActive(true);
                dialogue.text = alreadyTalkedText;
                answer1.text = "";
                answer2.text = "";
                answer3.text = "";
                playerscript.movelocked = true;
                talking = true;
                
                if (Input.GetKeyDown(KeyCode.Return) && talking)
                {
                    playerscript.movelocked = false;
                    talkSystem.SetActive(false);
                    talkPhase = 0;
                    highlightedAnswer = 1;
                    talking = false;
                }
            }
        }
        
        
        /* if (other.name.Equals("player"))
        {
            if (Input.GetKeyDown(KeyCode.Return) && !alreadyTalked)
            {
                talkSystem.SetActive(true);
                dialogue.text = dialogue1;
                answer1.text = answer11;
                answer2.text = answer12;
                answer3.text = answer13;
                
                playerscript.movelocked = true;
                
                if (highlightedAnswer > 1 && highlightedAnswer <= 3 && Input.GetKeyDown(KeyCode.UpArrow))
                {
                    highlightedAnswer -= 1;
                } else if (highlightedAnswer < 3 && highlightedAnswer >= 1 && Input.GetKeyUp(KeyCode.DownArrow))
                {
                    highlightedAnswer += 1;
                }
            } else if (alreadyTalked)
            {
                talkSystem.SetActive(true);
                dialogue.text = alreadyTalkedText;
                answer1.text = "";
                answer2.text = "";
                answer3.text = "";
                playerscript.movelocked = true;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    playerscript.movelocked = true;
                    talkSystem.SetActive(true);
                }
            }

            if (talkPhase == 1)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    dialogue.text = dialogue2;
                    answer1.text = answer21;
                    answer2.text = answer22;
                    answer3.text = answer23;

                    if (highlightedAnswer == rightanswer1)
                    {
                        favor++;
                    }
                    
                    Debug.Log("favor: " + favor);

                    highlightedAnswer = 1;
                    talkPhase++;
                }
            } else if (talkPhase == 2)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (highlightedAnswer == rightanswer1)
                    {
                        favor++;
                        talkPhase++;
                        answer1.text = "";
                        answer2.text = "";
                        answer3.text = "";
                        
                        Debug.Log("favor: " + favor);

                        if (favor == 2)
                        {
                            dialogue.text = successText;
                            dog.GetComponent<dogFriend>().dogFollow = true;
                        }
                        else
                        {
                            dialogue.text = failText;
                        }
                    }
                }
            } else if (talkPhase == 3)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    playerscript.movelocked = false;
                    alreadyTalked = true;
                    talkSystem.SetActive(false);
                    talkPhase = 0;
                }
            }
        } */
    }
}
