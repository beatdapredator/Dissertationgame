using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int doorOpening;
    /* order in which doors will need to spawn.
    1 = door will need a bottom opening
    2 = door will need a top opening
    3 = door will need a left opening
    4 = door will need a right opening
    */
    private RoomLayout differentRooms;
    private int procedural;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        differentRooms = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomLayout>();
        Invoke("spawn", 0.1f);
    }

    // Update is called once per frame
    void spawn()
    {
        //If room spawner is set to false then it will start to build rooms off the entry room
        //If the spawn point in the scene has no room spawned on that area then procedural will pick a random room from its array of rooms and place one there
        //each room has a token attached to each door where a room can spawn and will continue untill no more spawn tokens are available.
        if (spawned == false)
        {
            if (doorOpening == 1)
            {
                //spawn a room with an opening at the bottom
                procedural = Random.Range(0, differentRooms.bottomDoors.Length);
                Instantiate(differentRooms.bottomDoors[procedural], transform.position, differentRooms.bottomDoors[procedural].transform.rotation);
            }
            if (doorOpening == 2)
            {
                //spawn a room with an opening at the bottom
                procedural = Random.Range(0, differentRooms.topDoors.Length);
                Instantiate(differentRooms.topDoors[procedural], transform.position, differentRooms.topDoors[procedural].transform.rotation);

            }
            if (doorOpening == 3)
            {
                //spawn a room with an opening at the bottom
                procedural = Random.Range(0, differentRooms.leftDoors.Length);
                Instantiate(differentRooms.leftDoors[procedural], transform.position, differentRooms.leftDoors[procedural].transform.rotation);
            }
            if (doorOpening == 4)
            {
                //spawn a room with an opening at the bottom
                procedural = Random.Range(0, differentRooms.rightDoors.Length);
                Instantiate(differentRooms.rightDoors[procedural], transform.position, differentRooms.rightDoors[procedural].transform.rotation);
            }
            spawned = true;
        } 
    }

    //this blocks up the holes in my walls within my game.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            // If the spawned boolean spawned = false and the spawned bool for the current wall = false then it will create a plug for the hole.
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(differentRooms.Wall, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
