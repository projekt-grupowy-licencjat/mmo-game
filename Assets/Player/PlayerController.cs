using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float moveSpeed = 5.0f;
    public Rigidbody2D rigidBody;

    private Vector2 movement;
    readonly float diagonalLimiter = 0.7f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        
        // Limiting framerate for testing
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 30;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate()
    {
        if (movement.x != 0 && movement.y != 0)
        {
            movement *= diagonalLimiter;
        }
        
        rigidBody.MovePosition(rigidBody.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
    
}
