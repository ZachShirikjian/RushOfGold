using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //VARIABLES//
    public float speed; 
    
    //REFERENCES//
    public Rigidbody2D rb2D;
    public Rigidbody2D rb2D2;
    public float MoveSpeed = 5f;
    public float JumpPower;
    private Vector2 p1x, p2x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sidways movement control for player 1
        if (Input.GetKey(KeyCode.A))
        {
            p1x = new Vector2(-1f, 0f);
            rb2D.AddForce(p1x * MoveSpeed );
        }

        if (Input.GetKey(KeyCode.D))
        {
            p1x = new Vector2(1f, 0f);
            rb2D.AddForce(p1x * MoveSpeed);
        }

        //Sideways player control for player 2 
        if (Input.GetKey(KeyCode.J))
        {
            p2x = new Vector2(-1f, 0f); 
            rb2D2.AddForce(p1x * MoveSpeed);
        }

        if (Input.GetKey(KeyCode.L))
        {
            p2x = new Vector2(1f, 0f);
            rb2D2.AddForce(p1x * MoveSpeed);
        }



        //Jump and Attack controls for Player 1
        if (Input.GetKeyDown(KeyCode.W))
        {


        }

        if (Input.GetKeyDown(KeyCode.I))
        {

        }

        //Jump and Attack controls for Player 2
       // if (Input.GetKeyDown("a"))
        {

        }
       // if (Input.GetKeyDown("d"))
        {

        }
    }
}
