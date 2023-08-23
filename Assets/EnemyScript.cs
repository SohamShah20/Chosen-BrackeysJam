using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D enemy1Body;

    public float enemy1Speed;
    public int enemy1HP;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 20, 0);
        enemy1HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistancex = player.transform.position.x - transform.position.x;
        float playerDistancey = player.transform.position.y - transform.position.y;
        float playerDistance = Mathf.Sqrt(playerDistancex * playerDistancex + playerDistancey * playerDistancey);

        //chase player up to a certain distance
        if (playerDistance > 30)
        {
            enemy1Body.velocity = (new Vector2(playerDistancex, playerDistancey)) * enemy1Speed / playerDistance;
        }
        else
        {
            enemy1Body.velocity = Vector2.zero;
        }
        if (enemy1HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            enemy1HP -= 25;
        }
    }
}
