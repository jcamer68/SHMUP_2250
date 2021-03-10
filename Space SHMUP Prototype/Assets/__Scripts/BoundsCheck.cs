using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checks and ensures (if selected) the GameObject is screen
public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    //values intialized to set the radius of the bound padding (used in Main)
    public float radius = 1f;

    //allows user to choose whether the BoundsCheck
    //script will force a GameObject to stay on the screen or exit 
    public bool keepOnScreen = true;

    //variable to be used to determine if the Gameobject is on the screen
    [Header("Set Dynamically")]
    public bool isOnScreen = true;

    //variables to be used to hold the position of the camera
    [HideInInspector]
    public float camWidth, camHeight;

    //variables to determine if the ship has gone of the map in a certain direction
    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;


    void Awake()
    {
        //camHeight is set to the distance from the origin of the world to the top or bottom edge
        //of the screen in world coordinates
        camHeight = Camera.main.orthographicSize;

        //Gets distance from origin to the left or right edge of the screen
        camWidth = camHeight * Camera.main.aspect;
    }

    //Called every frame after Update() has been called to ensure it runs after Hero Update
    void LateUpdate()
    {
        //Creates a 3D Vector position equal to the Tranform of the GameObject
        Vector3 pos = transform.position;
        //Set to true 
        isOnScreen = true;
        //All set to false initially 
        offRight = offLeft = offUp = offDown = false;

        //The following four if statements checks if out of bounds in four directions

        //checks if off the right screen side 
        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            offRight = true;
        }

        //checks if off the left screen side 
        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            offLeft = true;
        }

        //checks if off the top screen side 
        if (pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
            offUp = true;
        }

        //checks if off the bottom screen side 
        if (pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
            offDown = true;
        }

        //assigns variable if object is not on screen in any direction
        isOnScreen = !(offRight || offLeft || offUp || offDown);

        //if not on screen and keepOnScreen has been set to true by user
        if ( keepOnScreen && !isOnScreen) {
            //does not allow the object to leave the screen
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
    }

    //A built-in MonoBehaviour method that draws the bounds in the Scene pane
    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
