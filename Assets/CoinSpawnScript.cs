using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnScript : MonoBehaviour
{
    public LogicScript logic;
    public GameObject kamera;
    public GameObject coin;

    bool spawnCoin = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = kamera.transform.position + new Vector3(0, -100, 0);

        if (logic.maxDepth % 10 == 0)
        {
            if (spawnCoin == true)
            {
                Instantiate(coin, new Vector3(transform.position.x + Random.Range(-100, 100), transform.position.y, 0), transform.rotation);
                spawnCoin = false;
            }
        }
        else
        {
            spawnCoin = true;
        }
    }
}
