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
    private bool facing = false;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;
    public KeyCode block;


    public GameObject leftBullet;
    public GameObject rightBullet;
    public GameObject leftBlock;
    public GameObject rightBlock;


    public Vector3 leftBulletOffset;
    public Vector3 rightBulletOffset;

    public float health;

    public Vector3 groundStretch;
    public Vector3 jumpStretch;
    public Vector3 walkStretch;






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

        if (Input.GetKey(jump))
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


        if (Input.GetKey(right))
        {
            facing = false;

            v += Vector3.right;





        }
        else if (Input.GetKey(left))
        {

            facing = true;

            v += Vector3.left;



        }

        if (facing == false)
        {

            if (Input.GetKeyDown(shoot))
            {

                Instantiate(rightBullet, GetComponent<Transform>().position + rightBulletOffset, Quaternion.identity);


            }
            if (Input.GetKeyDown(block))
            {

                Instantiate(rightBlock, GetComponent<Transform>().position + rightBulletOffset, Quaternion.identity);


            }

        }

        if (facing == true)
        {


            if (Input.GetKeyDown(shoot))
            {

                Instantiate(leftBullet, GetComponent<Transform>().position + leftBulletOffset, Quaternion.identity);


            }
            if (Input.GetKeyDown(block))
            {

                Instantiate(leftBlock, GetComponent<Transform>().position + leftBulletOffset, Quaternion.identity);


            }

        }


        return v;

    }

    private void FixedUpdate()
    {
        //if is jumping and can jump is true
        //add force vector3 up

        if (isJumping && canJump)
        {

            rb2d.AddForce(Vector3.up * jumpForce);

        }


    }


    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {

            canJump = true;
            Debug.Log("in collision stay area");
            GetComponent<Transform>().localScale = groundStretch;

            if (Input.GetKey(right))
            {

                GetComponent<Transform>().localScale = walkStretch;

            }
            if (Input.GetKey(left))
            {

                GetComponent<Transform>().localScale = walkStretch;

            }



        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        canJump = false;
        Debug.Log("left collision can't jump");
        GetComponent<Transform>().localScale = jumpStretch;

    }

}