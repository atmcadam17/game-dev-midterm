using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class dogFriend : MonoBehaviour
{
    public float speed;
    public float minDist;
    public float jumppower;

    // [HideInInspector]
    public bool dogFollow;
    private float timer;
    private Rigidbody rb;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (dogFollow)
        {
            Vector3 newDir = Vector3.RotateTowards(transform.forward, player.transform.position - this.transform.position, 100, 0);

            if (Vector3.Distance(transform.position, player.transform.position) > minDist)
            {
                this.transform.rotation = Quaternion.LookRotation(newDir);
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            
            // little jump
        
            // have a public void jump function on the dog
            // make the player script reference all the dogs (array?)
            //Invoke("Example",0.5f);
        }
    }

    void Example()
    {
    }
}