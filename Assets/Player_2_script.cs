using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Player_2_script : MonoBehaviour
{
    //Just a super simple movement script
    //We've done this before, so I won't comment it
    
    public static Player_2_script Player2;
    
    public Rigidbody2D RB;
    public float Speed = 5;
    public ProjectileController BulletPrefab;
    public bool scary;

    private void Awake()
    {
        //The one thing I do that's a little fancy is
          //I record the player to a static variable
          //so they're easy to find
        Player2 = this;

    }

    void Update()
    {
        //Player 2 is scary, enemies within range becomes scared
        
            

        //You've seen this movement code before
        Vector2 vel = Vector2.zero;
        if (Input.GetKey(KeyCode.RightArrow))
            vel.x = Speed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            vel.x = -Speed;
        if (Input.GetKey(KeyCode.UpArrow))
            vel.y = Speed;
        else if (Input.GetKey(KeyCode.DownArrow))
            vel.y = -Speed;
        RB.linearVelocity = vel;
    }
}
