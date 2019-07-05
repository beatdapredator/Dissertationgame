using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLayout : MonoBehaviour
{
    //this is an array of rooms with doors to the bottom.
    public GameObject[] bottomDoors;
    //this is an array of rooms with doors to the top.
    public GameObject[] topDoors;
    //this is an array of rooms with doors to the right.
    public GameObject[] rightDoors;
    //this is an array of rooms with doors to the left.
    public GameObject[] leftDoors;

    //this is the game object im using to plug holes
    public GameObject Wall;

    //I use this to place all of my rooms into a list as to find the amount of rooms that will spawn
    public List<GameObject> Rooms;

   
    public float waitTime;
    private bool spawnedBoss = false;
    public GameObject boss;

    private void Update()
    {
        // this if statement uses a for loop for the size of my list of rooms to find the last room spawned and place the boss in it.
        // It then sets the spawning boss bool to true.
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                if(i == Rooms.Count - 1)
                {
                    Instantiate(boss, Rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }           
        }
        else
        {
            waitTime -= Time.deltaTime; 
        }
    }

}
