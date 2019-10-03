using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeWall : MonoBehaviour
{
    public GameObject wall;
    
    // u can also do a spherecast which shoots out a sphere ray! like to see if u can fit thru doors
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit myHit = new RaycastHit();

            if (Physics.Raycast(myRay, out myHit, 500))
            {
                Instantiate(wall, myHit.point, Quaternion.identity);
            }
        }
    }
}
