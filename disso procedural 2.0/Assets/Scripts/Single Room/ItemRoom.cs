using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRoom : MonoBehaviour
{
    public GameObject[] Items;
    public Transform itemSpawn;


    // Start is called before the first frame update
    void Start()
    {
        itemSpawner();
    }

    // Update is called once per frame
    bool itemSpawner()
    {
        if (Physics2D.OverlapBox(itemSpawn.position, new Vector2(1, 1), 0) != null)
        {
            // if we hit something room is found so remove direction from list
            return false;
        }
        else
        {
            int randItem = Random.Range(0, Items.Length);
            Instantiate(Items[randItem], itemSpawn.position, Quaternion.identity);
            return true;
        }
    }
}
