using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public Vector3 blockMovement;
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
}
