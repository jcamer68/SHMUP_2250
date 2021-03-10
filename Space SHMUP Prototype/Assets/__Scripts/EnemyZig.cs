using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Subclass that will be used to override the Enemy script for Enemy_2
public class EnemyZig : Enemy
{
    //establishes private integer variable to be used to determine the directionality
    //of the enemy in the x axis
    private int _movement;

    //Runs at the beginning of the program/game
    public void Start()
    {
        //Randomizes an integer value between 0 and 1, multiplying it by
        //2 and subtracting 1 to end up with either 1 or -1
        _movement = Random.Range(0,2) * 2 - 1;
    }


    //overrides "Move" method from Enemy.cs script specific to Enemy_2
    //which is supposed to move on a 45 degree angle 
    public override void Move()
    {
        //Creates a 3D Vector position equal to the Tranform of the GameObject
        Vector3 pos = transform.position;

        //Moves the enemy downward at a constant speed 
        pos.y -= speed * Time.deltaTime;

        //Moves the enemy sideways at a constant speed
        //that is multiplied by either -1 or 1 depending on the random value
        //to either send the enemy to the left or right 
        pos.x += speed * _movement * Time.deltaTime;

        //sets the Transform of the GameObject equal to the changed pos value 
        transform.position = pos;
    }

}
