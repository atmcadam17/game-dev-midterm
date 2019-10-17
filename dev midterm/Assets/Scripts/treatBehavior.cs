using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class treatBehavior : MonoBehaviour
{
    public bool carrying;
    public float distToPickUp;
    public int enter1;
    private Rigidbody rb;
    
    void Start()
    {
        carrying = true;
        enter1 = 0;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && enter1 < 3)
        {
            enter1++;
        }
        
        if (Input.GetKeyDown(KeyCode.Return) && enter1 == 2 && carrying)
        {
            Invoke("setcarryfalse", .01f);
            transform.parent = null;
            enter1 = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Return) && !carrying && Vector3.Distance(this.transform.position,
            GameObject.Find("player").transform.position) < distToPickUp)
        {
            // THE STUFF IN HERE IS HAPPENING!?
            
            Invoke("setCarrytrue", .01f);
            var playertrans = GameObject.Find("player").transform;
            carrying = true;
            GameObject.Find("player").GetComponent<player>().carrying = true;
            this.transform.SetParent(GameObject.Find("player").transform);
            GameObject.Find("treat collider").GetComponent<pickuptreat>().spawnTreat();
            Destroy(this);
        }

        if (carrying == false)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        
        var playtrans = GameObject.Find("player").transform;

        if (carrying && this.transform.position != playtrans.position)
        {
            var x = Mathf.Lerp(this.transform.position.x, playtrans.position.x, .1f);
            var y = Mathf.Lerp(this.transform.position.y, playtrans.position.y + 1, .1f);
            var z = Mathf.Lerp(this.transform.position.z, playtrans.position.z - 1.5f, .1f);
            
            this.transform.position = new Vector3(x, y, z);
        }
        
        /*if (carrying && Input.GetMouseButtonDown(0))
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
        }*/
        
    }

    public void setCarrytrue()
    {
        carrying = true;
        GameObject.Find("player").GetComponent<player>().carrying = true;
    }
    
    public void setcarryfalse()
    {
        carrying = false;
        GameObject.Find("player").GetComponent<player>().carrying = false;
    }
    
    // check if object is at certain pos rel to player, lerp back if not
    
    // does stuff if you give them to dogs (make each dog a trigger)
    // if given to lone dog, set follow to true
}