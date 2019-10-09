﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
