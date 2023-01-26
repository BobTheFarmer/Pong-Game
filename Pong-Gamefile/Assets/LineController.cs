using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GameObject playerArrow;
    private const float maxLineLength = 4;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerArrow = GameObject.Find("Player Arrow");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerArrowPos = playerArrow.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; //Prevents the line from going into the camera safe zone

        if (mousePos.x < playerArrowPos.x) //Don't make line if it goes left
        {
            lineRenderer.enabled = false;
        } else {
            lineRenderer.enabled = true;

            float distance = Vector3.Distance(playerArrowPos, mousePos); //To make the line have a max distance, check the distance between both points
            if(distance > maxLineLength)
            {
                Ray r = new Ray(playerArrowPos, mousePos - playerArrowPos); //Subtracting gets the direction
                mousePos = r.GetPoint(maxLineLength); //Move the 'mouse' closer to the paddle to make the line shorter
            }
            //Set the line's pos to both the playerArrow and the mouse
            lineRenderer.SetPosition(0, playerArrowPos); //Use Arrow to make line start to the right
            lineRenderer.SetPosition(1, mousePos);
        }

        //Display base and arrow sprites 

    }

        
}
