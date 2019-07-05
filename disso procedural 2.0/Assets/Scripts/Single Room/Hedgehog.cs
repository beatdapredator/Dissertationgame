using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedgehog : MonoBehaviour
{
    public GameObject enemyShot;
    public Transform shotSpawn;
    private Transform enemy;

    public int hedgehogDamage = 2;
    public int chaseDistance;
    public float hedgehogShotspeed = 0.2f;
    public float hedgehogSpeed;
    public float angleIncrease;

    private float nextShot;
    private float nextAngle;

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
            if (Time.time > nextShot)
            {
                Vector2 shotDirection = new Vector2(Mathf.Cos((nextAngle + 90.0f) * Mathf.Deg2Rad),Mathf.Sin((nextAngle + 90.0f) * Mathf.Deg2Rad));
                nextShot = Time.time + hedgehogShotspeed;
                nextAngle = nextAngle + angleIncrease;
                Bullet playerBullet = Instantiate(enemyShot, shotSpawn.position, Quaternion.AngleAxis(nextAngle, new Vector3(0, 0, 1))).GetComponent<Bullet>();
                playerBullet.direction = shotDirection;
                Bullet secondplayerBullet = Instantiate(enemyShot, shotSpawn.position, Quaternion.AngleAxis((nextAngle + 180.0f), new Vector3(0, 0, 1))).GetComponent<Bullet>();
                secondplayerBullet.direction = -shotDirection;

            }
        }
    }
}