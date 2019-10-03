using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseRaycastTest : MonoBehaviour
{
    // move the cube to where u click

    public Transform thingToMove;
    private const int maxDist = 1000;
    
    void Start()
    {
        thingToMove = GameObject.Find("raycast test").GetComponent<Transform>();
    }

    void Update()
    {
        Ray coolerRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit coolHit = new RaycastHit();

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(coolerRay, out coolHit, maxDist))
            {
                /* what out does makes it an argument you pass in and it overwrites new info for you to use
                basically returns data to you
                like a return type when you need multiple things returned
                you need more than bool for whether or not it hit 
                
                you can also use layer masking to make it less choppy, similar to tags (ignore raycasting!)
                
                you can also also make it lerp between points to look real cute*/
                
                
                
                if (coolHit.collider.tag != "test")
                {
                    thingToMove.position = coolHit.point;
                }
            }
        }
    }
}
