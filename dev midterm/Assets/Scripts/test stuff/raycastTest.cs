using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class raycastTest : MonoBehaviour
{
    // ground check
    
    // step 1: declare variables
    
    // send out ray of set length, stops at certain distance
    const float MaxDist = .75f;
    
    void Start()
    {
        
    }

    void Update()
    {
        Ray coolRay = new Ray(this.transform.position, Vector3.down);
        Debug.DrawRay(this.transform.position, Vector3.down, Color.cyan, MaxDist);

        if (Physics.Raycast(coolRay, MaxDist))
        {
            Debug.Log("I am near the ground!");
        } else {
            this.transform.Rotate(0,2,0);
        }
    }
}
