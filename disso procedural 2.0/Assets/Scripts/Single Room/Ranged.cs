using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour
{
    public GameObject enemyShot;
    public Transform shotSpawn;
    private Transform enemy;

    public int rangeDamage = 2;
    public int rangeDistance;
    public int chaseDistance;
    public float shotRange = 10.0f;
    public float rangeShotspeed = 3.0f;
    public float speed;

    private float nextShot;

    // Start is called before the first frame update
    void Start()
    {
        //find the object player
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, enemy.position) < chaseDistance)
        {
            if (Vector2.Distance(transform.position, enemy.position) > rangeDistance)
            {
                //this will move the enemys from their position towards the enemy at a certin speed
                transform.position = Vector2.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
            }
            if (Time.time > nextShot)
            {
                Vector2 shotDirection = (enemy.position - shotSpawn.position).normalized;
                float angle = Vector2.Angle(new Vector2(0, 1), shotDirection) * Mathf.Sign(-shotDirection.x); 
                nextShot = Time.time + rangeShotspeed;
                Bullet playerBullet = Instantiate(enemyShot, shotSpawn.position, Quaternion.AngleAxis(angle, new Vector3(0, 0, 1))).GetComponent<Bullet>();
                playerBullet.direction = shotDirection;
            }
        }
    }
}
