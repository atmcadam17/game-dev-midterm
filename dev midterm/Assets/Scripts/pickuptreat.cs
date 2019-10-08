using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickuptreat : MonoBehaviour
{
    public GameObject treatPrefab;
    private int treatsLeft;
    
    void Start()
    {
        treatsLeft = 5;
    }

    void Update()
    {
        if (treatsLeft > 0)
        {
            // check if clicking on pile
            Ray clickingPile = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit = new RaycastHit();
            
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(clickingPile, out rayHit, 20))
                {
                    if (rayHit.collider.tag == "pile")
                    {
                        var newTreat = Instantiate(treatPrefab);
                        newTreat.transform.position = rayHit.point;
                        
                        treatsLeft--;
                    }
                }
            }
        }
    }
}
