using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakoutManager : MonoBehaviour
{
    //I use a static variable to make this accessible from anywhere
    //You can access this variable from anywhere by typing 'BreakoutManager.Me'
    //No need to capture the BreakoutManager in a variable name first, like you usually need
    public static BreakoutManager Me;
    //As a manager, I keep a link to all the major game elements
    public PaddleController Paddle;
    public BallController Ball;
    
    //The brick prefab
    public BrickController BrickPrefab;
    
    //I keep a list of all bricks that exist
    public List<BrickController> AllBricks;
    
    void Start()
    {         
        int n=0;
        while (n < 3)
        {
            n++;
            Debug.Log(n);
        }
        Debug.Log("DONE");
        for (float y = 0; y <= 3; y+=2)
        {
            for (float x = -7; x <= 7; x+=0.5f)
            {
                 Instantiate(BrickPrefab, new Vector3(x, y, 0),Quaternion.identity);
            }
        }
        //I need to register myself as 'the' BreakoutManager
        BreakoutManager.Me = this;

        //This is the code for spawning bricks. It's not very good.
        //How could we make this spawn lots of bricks more efficiently?
        //what i want, where i want it
        Instantiate(BrickPrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 3),0),
            Quaternion.identity);

        

        Instantiate(BrickPrefab, new Vector3(0, 1, 0), Quaternion.identity);
        Instantiate(BrickPrefab, new Vector3(0, 1.5f, 0), Quaternion.identity);
    }

    void Update()
    {
        //Check to see if all the bricks have been broken
        if (AllBricks.Count == 0)
        {
            //If so, win
            SceneManager.LoadScene("You Win");
        }
    }


    
}
