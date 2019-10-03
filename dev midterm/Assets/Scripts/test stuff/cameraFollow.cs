using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private Vector3 offset;
    private Transform RoombaTransform;
    void Start()
    {
        RoombaTransform = GameObject.Find("roomba").GetComponent<Transform>();
        offset = transform.position - RoombaTransform.position;
    }

    void Update()
    {
        // idk how to do the offset stuff
        this.transform.position = Vector3.MoveTowards(transform.position, RoombaTransform.position, 10);
    }
}
