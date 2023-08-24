using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public GameObject playerBullet;
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
    float phantomx;
    float phantomy;
    float phantomDistance;
    float retreatRange;
    bool retreat;

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
        if  (enemy1HP > 30)
        {
            shootCooldown += Time.deltaTime;
        }
        else
        {
            shootCooldown += 2 * Time.deltaTime;
        }
        
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
        retreatRange = 30;
        retreat = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistancex = player.transform.position.x - transform.position.x;
        playerDistancey = player.transform.position.y - transform.position.y;
        playerDistance = Mathf.Sqrt(playerDistancex * playerDistancex + playerDistancey * playerDistancey);
        phantomDistance = (Mathf.Sqrt((phantomx - transform.position.x) * (phantomx - transform.position.x) + (phantomy - transform.position.y) *
            (phantomy - transform.position.y)));

        if (!retreat)
        {
            //chase player up to a certain distance
            if (playerDistance > 50)
            {
                enemy1Body.velocity = (new Vector2(playerDistancex, playerDistancey)) * enemy1Speed / playerDistance;
                shoot(1.5f);
            }
            else
            {
                enemy1Body.velocity = Vector2.zero;
                shoot(0.75f);
            }
        }
        else
        {
            //retreat from the player
            if (phantomDistance < retreatRange)
            {
                enemy1Body.velocity = (new Vector2(Random.Range(-1.0f, -0.5f) * (phantomx - transform.position.x), 
                    Random.Range(-1.0f, -0.5f) * (phantomy - transform.position.y))) * enemy1Speed / phantomDistance;
                shoot(0.2f);
            }
            else
            {
                enemy1Speed /= 2f;
                retreat = false;
            }
        }
        
        if (enemy1HP <= 0)
        {
            Destroy(gameObject);
        }

        checkDir();
    }

    //Decrease HP and begin retreating when gotten hit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerBullet = GameObject.FindGameObjectWithTag("playerBullet"); //can't drag and drop because bullets are clones, if I use this in Start() bullets aren't created yet

        if (collision.gameObject.tag == "Sword" || collision.gameObject.tag == "playerBullet")
        {
            if (collision.gameObject.tag == "Sword")
            {
                enemy1HP -= 10;
                retreatRange = Random.Range(30, 80);
                phantomx = player.transform.position.x;
                phantomy = player.transform.position.y;
            }
            else
            {
                enemy1HP -= 5;
                retreatRange = Random.Range(10, 30);
                phantomx = playerBullet.transform.position.x;
                phantomy = playerBullet.transform.position.y;
            }
            
            if (enemy1HP == 50)
            {
                enemy1Speed *= 1.5f;
            }
            
            
            enemy1Speed *= 2f;
            retreat = true;
        }
    }
}
