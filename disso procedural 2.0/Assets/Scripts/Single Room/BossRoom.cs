using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public GameObject boss;
    public Transform bossSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(boss, bossSpawn.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
