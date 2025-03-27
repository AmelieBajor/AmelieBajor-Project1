using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public Vector3 blockMovement;
    public float speed;
    public SpriteRenderer mySprite;
    public float blockTimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Transform>().position += blockMovement;

        blockTimer += Time.deltaTime;

        if (blockTimer >= 1f)
        {
            Destroy(gameObject);

        }



    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {

            Destroy(gameObject);


        }


    }



}
