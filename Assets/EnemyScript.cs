using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemybullet;
    public Rigidbody2D enemy1Body;

    public float enemy1Speed;
    public int enemy1HP;
    float shootCooldown;
    public float xdirection;
    public float ydirection;
    float playerDistancex;
    float playerDistancey;
    float playerDistance;

    //checking for x and y directions
    void checkDir()
    {
        if (playerDistancey > 0)
        {
            ydirection = 1;
        }
        else if (playerDistancey < 0)
        {
            ydirection = -1;
        }
        if (playerDistancex > 0)
        {
            xdirection = 1;
        }
        else if (playerDistancex < 0)
        {
            xdirection = -1;
        }
    }

    //enemy shooting
    void shoot(float timeGap)
    {
        shootCooldown += Time.deltaTime;
        if (shootCooldown > timeGap)
        {
            Instantiate(enemybullet, transform.position + new Vector3(7.8f * xdirection, 7.8f * ydirection, 0), transform.rotation);
            shootCooldown = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 20, 0);
        enemy1HP = 100;
        shootCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistancex = player.transform.position.x - transform.position.x;
        playerDistancey = player.transform.position.y - transform.position.y;
        playerDistance = Mathf.Sqrt(playerDistancex * playerDistancex + playerDistancey * playerDistancey);

        //chase player up to a certain distance
        if (playerDistance > 30)
        {
            enemy1Body.velocity = (new Vector2(playerDistancex, playerDistancey)) * enemy1Speed / playerDistance;
            shoot(1.5f);
        }
        else
        {
            enemy1Body.velocity = Vector2.zero;
            shoot(0.75f);
        }
        if (enemy1HP <= 0)
        {
            Destroy(gameObject);
        }

        checkDir();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            enemy1HP -= 25;
        }
    }
}
