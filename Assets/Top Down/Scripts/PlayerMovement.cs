using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Just a super simple movement script
    //We've done this before, so I won't comment it
    
    public static PlayerMovement Player;
    
    public Rigidbody2D RB;
    public float Speed = 5;
    public ProjectileController BulletPrefab;

    private void Awake()
    {
        //The one thing I do that's a little fancy is
          //I record the player to a static variable
          //so they're easy to find
        Player = this;
    }

    void Update()
    {
        //You've seen this movement code before
        Vector2 vel = Vector2.zero;
        if (Input.GetKey(KeyCode.D))
            vel.x = Speed;
        else if (Input.GetKey(KeyCode.A))
            vel.x = -Speed;
        if (Input.GetKey(KeyCode.W))
            vel.y = Speed;
        else if (Input.GetKey(KeyCode.S))
            vel.y = -Speed;
        RB.linearVelocity = vel;
        
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If I walk into the exit. . .
        if (other.gameObject.CompareTag("Exit"))
        {
            //Win the game!
            SceneManager.LoadScene("You Win");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //If I walk into a monster or other hazard. . .
        if (other.gameObject.CompareTag("Hazard"))
        {
            //Lose the game!
            SceneManager.LoadScene("You Lose");
        }
    }
}
