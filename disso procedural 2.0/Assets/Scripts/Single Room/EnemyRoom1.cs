using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom1 : MonoBehaviour
{
    public GameObject[] Enemy;
    public Transform[] location;
    private int numenemySpawned;

    // Start is called before the first frame update
    void Start()
    {
        spawner();
    }

    bool enemySpawned(int randomIndex)
    {
        if (Physics2D.OverlapBox(location[randomIndex].position, new Vector2(1, 1), 0) != null)
        {
            // if we hit something room is found so remove direction from list
            return false;
        }
        else
        {
            int randEnemy = Random.Range(0, Enemy.Length); 
            Instantiate(Enemy[randEnemy], location[randomIndex].position, Quaternion.identity);
            return true;
        }

    }

    void spawner()
    {
        List<int> spawned = new List<int>();
        spawned.Add(0);
        spawned.Add(1);
        spawned.Add(2);
        spawned.Add(3);
        spawned.Add(4);
        spawned.Add(5);
        spawned.Add(6);
        spawned.Add(7);


        while(spawned.Count > 0 && numenemySpawned < 4)
        {
            int randPlace = Random.Range(0, spawned.Count);
            int randomIndex = spawned[randPlace];

            if (enemySpawned(randomIndex) == false)
            {
                spawned.Remove(randomIndex);
            }
            else
            {
                numenemySpawned = numenemySpawned + 1;
            }
        }
    }

}