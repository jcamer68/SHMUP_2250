using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Subclass that will be used to override the Enemy script for Enemy_1
public class EnemyStraight : Enemy
{

    //overrides "Move" method from Enemy.cs script specific to Enemy_1
    //which is only supposed to go straight down 
    public override void Move()
    {
        //Creates a 3D Vector position equal to the Tranform of the GameObject
        Vector3 pos = transform.position;

        //changes the value of pos vector in the y direction to
        //move the enemy downward at a constant speed 
        pos.y -= speed * Time.deltaTime;

        //sets the Transform of the GameObject equal to the changed pos value 
        transform.position = pos;
    }
}
