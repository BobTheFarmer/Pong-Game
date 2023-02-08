using System.Collections;, 
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GameObject playerArrow;
    private GameObject lineStartSprite;
    private GameObject lineEndSprite;
    public float lineLengthMultipier;
    public float lenthToMaxLengthRatio;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerArrow = GameObject.Find("Player Arrow Base");
        lineEndSprite = GameObject.Find("Player Arrow End");
        lineStartSprite = GameObject.Find("Player Arrow");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerArrowPos = playerArrow.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 directionToMouse = mousePos - playerArrowPos;  //Subtracting gets the direction

        mousePos.z = 0; //Prevents the line from going into the camera safe zone

        if (mousePos.x < lineStartSprite.transform.position.x) //Don't make line if it goes left
        {
            lineRenderer.enabled = false;
            playerArrow.SetActive(false);
            lineEndSprite.SetActive(false);

        } else {
            playerArrow.SetActive(true);
            lineRenderer.enabled = true;
            lineEndSprite.SetActive(true);


            //To make the line have a max distance, check the distance between both 
            float distance = Vector3.Distance(playerArrowPos, mousePos);
            float lineLength;
            if (distance >  lenthToMaxLengthRatio)
            {
                lineLength = lenthToMaxLengthRatio * lineLengthMultipier;
            }
            else
            {
                lineLength = lineLengthMultipier * distance;
            }

            Ray r = new Ray(playerArrowPos, directionToMouse); 
            Vector3 lineEnd = r.GetPoint(lineLength);
            lineEnd.z = 0;

            //Set the line's pos to both the playerArrow and the lineEnd
            lineRenderer.SetPosition(0, playerArrowPos); //Use Arrow to make line start to the right
            lineRenderer.SetPosition(1, lineEnd);
            
            //Display arrow sprite
            lineEndSprite.transform.position = lineEnd;
            //lineEndSprite.transform.rotation = Quaternion.Rotaye
            //Quaternion tempAngle = Quaternion.LookRotation(directionToMouse, Vector3.up);
            //wtempAngle.x = 0;
            //Debug.Log(tempAngle);

        }
    }   
}
