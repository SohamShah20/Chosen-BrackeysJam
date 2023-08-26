using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnScript : MonoBehaviour
{
    public LogicScript logic;
    public GameObject kamera;
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;

    bool spawnRock = false;
    int rockType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = kamera.transform.position + new Vector3(0, -100, 0);

        if (logic.maxDepth % 3 == 0)
        {
            rockType = Random.Range(1, 4);
            if (spawnRock == true)
            {
                if (rockType == 1)
                {
                    Instantiate(rock1, new Vector3(transform.position.x + Random.Range(-100f, 100f), transform.position.y + Random.Range(-30f, 30f), 0), transform.rotation);
                }
                else if (rockType == 2)
                {
                    Instantiate(rock2, new Vector3(transform.position.x + Random.Range(-100f, 100f), transform.position.y + Random.Range(-30f, 30f), 0), transform.rotation);
                }
                else
                {
                    Instantiate(rock3, new Vector3(transform.position.x + Random.Range(-100f, 100f), transform.position.y + Random.Range(-30f, 30f), 0), transform.rotation);
                }

                spawnRock = false;
            }
        }
        else
        {
            spawnRock = true;
        }
    }
}
