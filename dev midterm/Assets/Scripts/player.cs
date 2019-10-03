using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float movespeed;
    public float turnspeed;
    public float jumppower;

    private Rigidbody rb;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            this.transform.Translate(new Vector3(0,0,-movespeed));
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            this.transform.Translate(new Vector3(0,0,movespeed));
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            this.transform.Rotate(new Vector3(0,turnspeed,0));
        }
        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            transform.eulerAngles += new Vector3(0,-turnspeed,0);
        }
        
        // check if jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0,jumppower,0), ForceMode.Impulse);
        }

        // if (transform.rotation.x != 0)
        // {
        //     transform.rotation = Quaternion.identity;
        // }
    }
}
