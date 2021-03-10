using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Superclass used for the other two Enemy scripts to override (establishes bounds check etc.)
public class Enemy : MonoBehaviour
{
    [Header("set in Inspector: Enemy")]

    //establishes base speed value
    public float speed = 20f;

    //private variable that allows Enemy script to store reference to BoundsCheck script (did not add underscore because of convention in Textbook handout)
    private BoundsCheck bndCheck;

   
    void Awake()
    {
        //Searches for BoundsCheck script component attached to Gameobject, if not found, set to null
        bndCheck = GetComponent<BoundsCheck>();
    } 


    // Update is called once per frame
    void Update()
    {
        //Calls the move function which becomes overriden by other two Enemy subclass scripts
        Move();

        //If enemy leaves screen on left, right, or bottom, destroy it
        if ( bndCheck != null && (bndCheck.offDown || bndCheck.offLeft || bndCheck.offRight) )
        {            
            Destroy( gameObject );
        } 
    }

    //method to be overridden by EnemyStraight & EnemyZig 
    //used to get the current position of the enemy, alter it according to the enemy type, and reset the position of the GameObject
    public virtual void Move() { 
    }
}
