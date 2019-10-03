using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roombaController : MonoBehaviour
{
    public float maxDist;
    public float moveSpeed;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Ray myRay = new Ray(this.transform.position, this.transform.forward);
        
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.cyan, maxDist);

        if (Physics.Raycast(myRay, maxDist))
        {
            float rand = Random.value;
            if (rand < 0.5f)
            {
                // turn left
                this.transform.Rotate(0,-90,0);
            }
            else
            {
                // turn right
                this.transform.Rotate(0,90,0);
            }
        }
        else
        {
            this.transform.Translate(0,0,moveSpeed*Time.deltaTime);
        }
    }
}
