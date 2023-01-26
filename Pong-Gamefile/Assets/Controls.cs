using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move player paddle based on input
        //Also use playerPositon to prevent the paddle from breifly exiting the scene
        Vector3 playerPosition = transform.position;
        if(Input.GetKey("s") || Input.GetKey("down"))
        {
            playerPosition.y -= playerSpeed;
        }
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            playerPosition.y += playerSpeed;
        }

        //Limit to stay in screen
        if (playerPosition.y > 5f - 3.5f/2f)
        {
            playerPosition.y = 5f - 3.5f/2f;
        }
        if (playerPosition.y < -5f + 3.5f/2f) 
        {
            playerPosition.y = -5f + 3.5f/2f;
        }

        transform.position = playerPosition;
    }
}
