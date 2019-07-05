using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public RoomInfo[,] grid;
    public int bossPathLength;
    public int itemPathLength;
    public int normPathLength;
    

    // Start is called before the first frame update
    void Start()
    {
        grid = new RoomInfo[32, 32];
    }

    void genBossPath(int x,int y)
    {

        //Hold last position
        int lastx = 16;
        int lasty = 16;

        //for loop to iterate for length of path
        for (int i = 0; i < bossPathLength; i++)
        {
            //set new position as a room
            int direction = Random.Range(0, 4);
            //0 = up
            if (direction == 0)
            {
                y = lasty + 1;
                x = lastx;
                //check if room available
                if (grid[x, y] == null)
                {
                    
                }

            }
            //1 = down
            if (direction == 1)
            {
                y = lasty - 1;
                x = lastx;
                //check if room available
                if (grid[x, y] == null)
                {

                }
            }
            //2 = right
            if (direction == 2)
            {
                x = lastx + 1;
                y = lasty;
                //check if room available
                if (grid[x, y] == null)
                {

                }
            }
            //3 = left
            if (direction == 3)
            {
                x = lastx - 1;
                y = lasty;
                //check if room available
                if (grid[x, y] == null)
                {

                }
            }

        }
        //determin where doors are made

        //determin where the doorways are (up,down,left,right)
        //determin a path based off created doorways
        
    }
    void genItemPath()
    {

    }
    void genNormPath()
    {

    }
}
