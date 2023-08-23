using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1Script : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;

    public float bullet1Speed;
    float playerDistancex;
    float playerDistancey;
    float playerDistance;
    float cameraDistancex;
    float cameraDistancey;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        playerDistancex = player.transform.position.x - transform.position.x;
        playerDistancey = player.transform.position.y - transform.position.y;
        playerDistance = Mathf.Sqrt(playerDistancex * playerDistancex + playerDistancey * playerDistancey);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += ((new Vector3(playerDistancex, playerDistancey, 0)) * bullet1Speed / playerDistance) * Time.deltaTime;
        cameraDistancex = mainCamera.transform.position.x - transform.position.x;
        cameraDistancey = mainCamera.transform.position.y - transform.position.y;

        if (cameraDistancex > 150 || cameraDistancex < -150 || cameraDistancey > 100 || cameraDistancey < -100)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
