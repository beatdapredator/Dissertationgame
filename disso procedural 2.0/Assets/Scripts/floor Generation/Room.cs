using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public GameObject roomTemplate;
    private int distancefromStart;
    public GameObject[] solidWall;
    public GameObject[] Doors;
    public Transform[] roomSpawn;
    public float enemyspawnProbability;
    public enum WallDirection
    {
        left,right,bottom,top
    };

    
    // Start is called before the first frame update
    void Start()
    {
        if (distancefromStart < 5)
        {
            if (distancefromStart == 0)
            {
                spawner();
                spawner();
                spawner();
                spawner();
                //placeRoom(0);
                //placeRoom(1);
                //placeRoom(2);
                //placeRoom(3);
            }
            else
            {
                //if (distancefromStart == 3)
                //{
                //    spawner();
                //    spawner();
                //}
                //else
                //{
                //    spawner();
                //}

                //spawner();
                Invoke("spawner", 2.0f);
            }
        }
        if (distancefromStart > 0)
        {
            RoomSpawnManager manager;
            manager =  FindObjectOfType<RoomSpawnManager>();
            float rand = Random.Range(0.0f, 1.0f);
            if (manager.hasbossSpawn == false && distancefromStart == 5)
            {
                GetComponent<BossRoom>().enabled = true;
                manager.hasbossSpawn = true;
            }
            else if(manager.hasitemroomSpawn == false && distancefromStart == 5)
            {
                GetComponent<ItemRoom2>().enabled = true;
                manager.hasitemroomSpawn = true;
            }
            else if (rand < enemyspawnProbability)
            {
                GetComponent<EnemyRoom1>().enabled = true;
                GetComponent<Ob>().enabled = true;
            }
            else
            {
                GetComponent<Ob>().enabled = true;
            }

        }

    }

    bool placeRoom(int facingDirection)
    {
        
        if (Physics2D.OverlapBox(roomSpawn[facingDirection].position, new Vector2(12, 12), 0) != null)
        {
            // if we hit something room is found so remove direction from list
           return false;

        }
        else
        {
            //create a new room at the spawn location of the facing direction which is the random direction choosen in spawner
            Room newRoom = Instantiate(roomTemplate, roomSpawn[facingDirection].position, Quaternion.identity).GetComponent<Room>();
            newRoom.solidWall[0].SetActive(true);
            newRoom.solidWall[1].SetActive(true);
            newRoom.solidWall[2].SetActive(true);
            newRoom.solidWall[3].SetActive(true);
            newRoom.distancefromStart = this.distancefromStart + 1;

            if (facingDirection == (int)WallDirection.left)
            {
                //if there is a room to the left then it will set the left solid wall and right solid walls to inactive
                solidWall[(int)WallDirection.left].SetActive(false);
                newRoom.solidWall[(int)WallDirection.right].SetActive(false);
            }

            if (facingDirection == (int)WallDirection.right)
            {
                //if there is a room to the right then it will set the right solid wall and left solid walls to inactive
                solidWall[(int)WallDirection.right].SetActive(false);
                newRoom.solidWall[(int)WallDirection.left].SetActive(false);
            }

            if (facingDirection == (int)WallDirection.bottom)
            {
                //if there is a room to the bottom then it will set the bottom solid wall and top solid walls to inactive
                solidWall[(int)WallDirection.bottom].SetActive(false);
                newRoom.solidWall[(int)WallDirection.top].SetActive(false);
            }

            if (facingDirection == (int)WallDirection.top)
            {
                //if there is a room to the top then it will set the top solid wall and bottom solid walls to inactive
                solidWall[(int)WallDirection.top].SetActive(false);
                newRoom.solidWall[(int)WallDirection.bottom].SetActive(false);
            }
            return true;
        }

    }

    void spawner()
    {
        List<int> direction = new List<int> ();
        direction.Add(0);
        direction.Add(1);
        direction.Add(2);
        direction.Add(3);

        bool hasplacedRoom = false;

        while (hasplacedRoom == false && direction.Count > 0)
        {
            int rand = Random.Range(0, direction.Count);
            int facingDirection = direction[rand];
            //this checks whether room is placed in facing direction determined by a random number.
            if(placeRoom(facingDirection) == false)
            {
                direction.Remove(facingDirection);
            }
            else
            {
                hasplacedRoom = true;
            }
        }
    }
}
