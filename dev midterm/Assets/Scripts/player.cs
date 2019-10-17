using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float movespeed;
    public float turnspeed;
    public float jumppower;
    public float jumpRayDist;
    private Array treatList;
    public pickuptreat respawn;
    

    [HideInInspector]
    public bool movelocked;
    public bool carrying;
            
    private Rigidbody rb;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        carrying = false;
        respawn = GameObject.Find("treat collider").GetComponent<pickuptreat>();
    }

    void Update()
    {
        treatList = GameObject.FindGameObjectsWithTag("treat");
        if (carrying)
        {
            checkTreats();
        }
        
        if (!movelocked)
        {
            Ray downcheck = new Ray(this.transform.position, Vector3.down);
                
            if (Physics.Raycast(downcheck, jumpRayDist))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(new Vector3(0,jumppower,0), ForceMode.Impulse);
                }            
            }
        }
    }

    private void FixedUpdate()
    {
        if (!movelocked)
        {
            if (Input.GetKey(KeyCode.DownArrow)){
                this.transform.Translate(new Vector3(0,0,-movespeed));
            } else if (Input.GetKey(KeyCode.UpArrow)){
                this.transform.Translate(new Vector3(0,0,movespeed));
            }

            if(Input.GetKey(KeyCode.RightArrow)){
                this.transform.Rotate(new Vector3(0,turnspeed,0));
            } else if(Input.GetKey(KeyCode.LeftArrow)){
                transform.eulerAngles += new Vector3(0,-turnspeed,0);
            }
        }
    }

    public void checkTreats()
    {
        var treats = 0;
        
        foreach (var treat in treatList)
        {
            treats++;
            
            if (treats > 1)
            {
                Destroy(GameObject.FindGameObjectWithTag("treat"));
                treats--;
            }
        }
    }
}
