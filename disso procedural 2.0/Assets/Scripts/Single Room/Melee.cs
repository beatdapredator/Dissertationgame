using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public int meleeDamage = 1;
    public float meleeDistance;
    public float chaseDistance;
    public float speed;
    private Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, enemy.position) < chaseDistance)
        {
            if (Vector2.Distance(transform.position, enemy.position) > meleeDistance)
            {
                //this will move the enemys from their position towards the enemy at a certin speed
                transform.position = Vector2.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
            }
        }

    }
}


