using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float movespeed;
    public float turnspeed;
    public float jumppower;
    public float jumpRayDist;
    
    [HideInInspector] public bool movelocked;
            
    private Rigidbody rb;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
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
}
