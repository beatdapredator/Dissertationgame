using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerShot;
    public Transform player;
    public Transform shotSpawn;
    public int playerDamage = 1;
    public float playerSpeed;
    public float playerRange = 10.0f;
    public float playerShotspeed = 3.0f;
    public float firerateIncrease;
    public float speedIncrease;

    private float nextShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    public void SpeedUp()
    {
        playerSpeed = playerSpeed * speedIncrease;
    }

    public void fireRate()
    {
        playerShotspeed = playerShotspeed / firerateIncrease;
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.Translate(new Vector2(0, 1) * playerSpeed * Time.deltaTime); 
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.Translate(new Vector2(-1, 0) * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.Translate(new Vector2(0, -1) * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.Translate(new Vector2(1, 0) * playerSpeed * Time.deltaTime);
        }
    }

    void Shooting()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextShot)
        {
            nextShot = Time.time + playerShotspeed;
            Bullet playerBullet = Instantiate(playerShot, shotSpawn.position, Quaternion.AngleAxis(0.0f, new Vector3(0, 0, 1))).GetComponent<Bullet>();
            playerBullet.direction = new Vector2(0, 1);

        }
        if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextShot)
        {
            nextShot = Time.time + playerShotspeed;
            Bullet playerBullet = Instantiate(playerShot, shotSpawn.position, Quaternion.AngleAxis(180.0f, new Vector3(0, 0, 1))).GetComponent<Bullet>();
            playerBullet.direction = new Vector2 (0,-1);

        }
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextShot)
        {
            nextShot = Time.time + playerShotspeed;
            Bullet playerBullet = Instantiate(playerShot, shotSpawn.position, Quaternion.AngleAxis(270.0f, new Vector3(0, 0, 1))).GetComponent<Bullet>();
            playerBullet.direction = new Vector2(1, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextShot)
        {
            nextShot = Time.time + playerShotspeed;
            Bullet playerBullet = Instantiate(playerShot, shotSpawn.position, Quaternion.AngleAxis(90.0f, new Vector3(0, 0, 1))).GetComponent<Bullet>();
            playerBullet.direction = new Vector2(-1, 0);
        }
    }
}
