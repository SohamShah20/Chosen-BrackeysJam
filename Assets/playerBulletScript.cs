using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject mainCam;

    public float playerBulletSpeed;
    float curveTime;
    float enemyDistancex;
    float enemyDistancey;
    float enemyDistance;
    float cameraDistancex;
    float cameraDistancey;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        curveTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        curveTime += Time.deltaTime;
        if (curveTime < 1)
        {
            enemyDistancex = enemy.transform.position.x - transform.position.x;
            enemyDistancey = enemy.transform.position.y - transform.position.y;
            enemyDistance = Mathf.Sqrt(enemyDistancex * enemyDistancex + enemyDistancey * enemyDistancey);
        }

        transform.position += ((new Vector3(enemyDistancex, enemyDistancey, 0)) * playerBulletSpeed / enemyDistance) * Time.deltaTime;
        cameraDistancex = mainCam.transform.position.x - transform.position.x;
        cameraDistancey = mainCam.transform.position.y - transform.position.y;

        if (cameraDistancex > 150 || cameraDistancex < -150 || cameraDistancey > 100 || cameraDistancey < -100)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
