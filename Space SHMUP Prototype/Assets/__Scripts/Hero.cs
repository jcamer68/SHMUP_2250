using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Fields used to control the movement of the ship

    //controls movement speed
    public float speed = 30;
    //both used to control the rotation of ship
    public float rollMult = -45;
    public float pitchMult = 30;

    //holds the Gameobject that was last triggered (by collision)
    private GameObject _lastTriggerGo = null;

    // Update is called once per frame
    void Update()
    {
        //Returns a float between -1 and 1 in value (with default of 0)
        //for each of the respective directions
        //Pulls in information from the Input class 
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");


        //Creates a representation of a 3D vector and assigns it to
        //the Tranform of the GameObject
        Vector3 pos = transform.position;
        //Change pos vector based on the user input stored in xAxis and yAxis
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        //Change transform.position in accordance to the new pos values
        transform.position = pos;

        //Rotate the ship to make it feel more dynamic
        //Based on the speed at which it is moving
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
    }

    //method that determines if a collision has occurred 
    private void OnTriggerEnter(Collider other)
    {
        //used to grab particular gameobject that caused collision
        Transform rootT = other.gameObject.transform.root;
        //set this root gameobject to go variable
        GameObject go = rootT.gameObject;

        //if lastTriggerGo is same as go (current triggering GameObject)
        //This collision is ignored as a duplicate, and function returns
        if (go == _lastTriggerGo)
        {
            return;
        }

        //assign go to lastTriggerGo so it is updated before next time
        //OnTriggerEnter() is called
        _lastTriggerGo = go;

        //if tag of GameObject is set to "Enemy"
        if (go.tag == "Enemy")
        {
            //go, enemy Gameobject is destroyed along with the Hero
            Destroy(go);
            Destroy(this.gameObject);
        }

        //if tag of GameObject is not set to "Enemy"
        else
        {
            print("Triggered by non-Enemy: " + go.name);
        }
    }
}
