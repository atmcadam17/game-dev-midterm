using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treatBehavior : MonoBehaviour
{
    private bool carrying;
    
    void Start()
    {
        carrying = true;
    }

    void Update()
    {
        if (carrying && Input.GetMouseButtonDown(0))
        {
            carrying = false;
        } else if (Input.GetMouseButtonDown(0))
        {
            carrying = true;
        }
        
        Ray position = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        
        if (carrying)
        {
            if (Physics.Raycast(position, out hit, 200))
            {
                if (hit.collider.tag != "treat")
                {
                    transform.position = hit.point;
                }
            }
        }
    }
    
    // does stuff if you give them to dogs (make each dog a trigger)
    // if given to lone dog, set follow to true
}
