using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lonedogMove : MonoBehaviour
{
    public float moveSpeed;
    public float maxDist;
    [HideInInspector] public bool movement;
    
    void Start()
    {
        movement = true;
    }

    void Update()
    {
        Ray myRay = new Ray(this.transform.position, this.transform.forward);
        
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.cyan, maxDist);

        if (Physics.Raycast(myRay, maxDist) && movement)
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
        else if (movement)
        {
            this.transform.Translate(0,0,moveSpeed*Time.deltaTime);
        }
    }
}
