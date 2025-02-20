using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public float speed = 5;

    // var stores our direction
    private Vector3 dir;
    private Rigidbody2D rb2d;

    public float jumpForce;
    public bool canJump;
    private bool isJumping = false;


    // private doesn't have to be written down to make the var private
    


    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody script off of object that it is attached to and store it in our variable
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Calling the direction funtion that returns a vector and storing it in dir
        dir = Direction();


        //Time.deltaTime keeps game consistent in different computer speeds
        transform.Translate(dir * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.Space))
        {

            isJumping = true;

        }

        else
        {
            isJumping = false;

        }

    }

    // Function that will return a vector3
    private Vector3 Direction()
    {

        //temporary vector to hold our direction
        //made a variable called v and we are storing vector3.zero
        //(0,0,0)
        Vector3 v = Vector3.zero;


        if(Input.GetKey(KeyCode.D))
        {

            v += Vector3.right;

        }
        else if (Input.GetKey(KeyCode.A))
        {

            v += Vector3.left;

        }

        return v;

    }

    private void FixedUpdate()
    {
        //if is jumping and can jump is true
        //add force vector3 up

        if(isJumping && canJump)
        {

            rb2d.AddForce(Vector3.up * jumpForce);

        }


    }


    private void OnCollisionStay2D(Collision2D collision)
    {

        canJump = true;
        Debug.Log("in collision stay area");

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        canJump = false;
        Debug.Log("left collision can't jump");

    }

}
