using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    //A singleton for Main that follows textbook convention
    static public Main S;

    [Header("Set in Inspector")]
    //Array of enemy prefabs
    public GameObject[] prefabEnemies;
    //number of enemies per second
    public float enemySpawnPerSecond = 0.5f;
    //Padding for position
    public float enemyDefaultPadding = 1.5f;

    //private variable that allows script to store a reference to BoundsCheck script
    private BoundsCheck _bndCheck;

    void Awake()
    {
        S = this;
        //Set bndCheck to reference the BoundsCheck component on this GameObject
        _bndCheck = GetComponent<BoundsCheck>();

        //Invoke SpawnEnemy() once (in 2 seconds, based on default values)
        Invoke("SpawnEnemy", 1f/enemySpawnPerSecond );
    }


    //method used to spawn enemies
    public void SpawnEnemy()
    {
        // Pick a random Enemy prefab to instantiate
        int ndx = Random.Range(0, prefabEnemies.Length);
        //instantiate one of the enemy prefab  based on random int value 
        GameObject go = Instantiate<GameObject>( prefabEnemies[ ndx ] );

        // Position the Enemy above the screen with a random x position
        float enemyPadding = enemyDefaultPadding;
        //if  the selected enemy prefab has a BoundsCheck component
        //instead read the radius 
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs( go.GetComponent<BoundsCheck>().radius );
        }

        //Set initial position for the spawned Enemy
        Vector3 pos = Vector3.zero;
        //retrieves max and min x values for random placement
        float xMin = -_bndCheck.camWidth + enemyPadding;
        float xMax = _bndCheck.camWidth - enemyPadding;
        //spawns from random position on x axis
        pos.x = Random.Range(xMin, xMax );
        //spawns from top of the game scene
        pos.y = _bndCheck.camHeight + enemyPadding;
        //set these positional values to the enemy
        go.transform.position = pos;

        //Invoke SpawnEnemy() again
        Invoke( "SpawnEnemy", 1f / enemySpawnPerSecond );
    }
}
