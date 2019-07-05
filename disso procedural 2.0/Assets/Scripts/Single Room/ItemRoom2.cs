using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRoom2 : MonoBehaviour
{
    public GameObject[] Items;
    public Transform itemSpawn;

    // Start is called before the first frame update
    void Start()
    {
        int randItem = Random.Range(0, Items.Length);
        Instantiate(Items[randItem], itemSpawn.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
