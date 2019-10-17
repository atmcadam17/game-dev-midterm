using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class pickuptreat : MonoBehaviour
{
    public GameObject treatPrefab;
    private specialTalk partyTalk;
    private GameObject player;
    private bool carrying;
    private bool treatExists;
    public float spawnDist;
    
    void Start()
    {
        player = GameObject.Find("player");
        partyTalk = GameObject.Find("party collider").GetComponent<specialTalk>();
        carrying = false;
        treatExists = false;
    }

    void Update()
    {
        if (GameObject.FindWithTag("treat") != null)
        {
            treatExists = false;
        }
        
        carrying = GameObject.Find("player").GetComponent<player>().carrying;
        /*if (treatsLeft > 0)
        {
            // check if clicking on pile
            Ray clickingPile = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit = new RaycastHit();
            
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(clickingPile, out rayHit, 20, LayerMask.GetMask("pile")))
                {
                    if (rayHit.collider.tag == "pile")
                    {
                        var newTreat = Instantiate(treatPrefab);
                        newTreat.transform.position = rayHit.point;
                        
                        treatsLeft--;
                    }
                }
            }
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Equals("player") && !partyTalk.inRange && !treatExists && !carrying &&
            Input.GetKeyDown(KeyCode.Return))
        {
            spawnTreat();
        }
    }

    public void spawnTreat()
    {
        player.GetComponent<player>().carrying = true;
        var newTreat = Instantiate(treatPrefab);
        newTreat.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
            player.transform.position.z + spawnDist);
        newTreat.transform.parent = player.transform;
    }
}
