using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    //They need to know the player exists to chase them
    public PlayerMovement Target;
    //How fast do I move?
    public float Speed = 4;
    //My rigidbody
    public Rigidbody2D RB;

    public static Player_2_script Player2;
    public bool scary;

    void Start()
    {
        //If I don't have the player assigned, use their static variable to find them
        if(Target == null) Target = PlayerMovement.Player;
    }

    void Update()
    {
        //make a bool for if enemy is scared it runs - of the player

        //If there is no player, don't chase
        if (Target == null) return;
        
        //Calculate what direction the player is in
        Vector3 offset =  Target.transform.position - transform.position;
        Debug.Log(offset.magnitude);
        //Normalize the direction to make it always add up to 1, then multiply it by my speed
        RB.linearVelocity = offset.normalized * Speed;
        

        //Trying to have the enemy go in oposite direction of player 2

        //Vector3 offset2 = transform.position - Target.transform.position;
        //RB.linearVelocity = offset.normalized * Speed;

        //This code was hard to fix, so I tried something different;
        //if (Player2 = scary) true;
        //-transform.position - Player2.transform.position;
        //This is what I tried instead but I can't figure it out;
        //if Player2 = Vector3 (pos 
        //I couldn't find the reference I had for this and I couldn't remember how the code was written. . .

    }

    //If I get hit by a bullet. . .
    public void GetShot()
    {
         Destroy(gameObject);
    }


}
