using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public PlayerScript playerscript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x - transform.position.x > 45)
        {
            transform.position += Vector3.right * playerscript.speed * Time.deltaTime;
        }
        if (player.transform.position.x - transform.position.x < -45)
        {
            transform.position += Vector3.left * playerscript.speed * Time.deltaTime;
        }
        if (player.transform.position.y - transform.position.y > 20)
        {
            transform.position += Vector3.up * playerscript.speed * Time.deltaTime;
        }
        if (player.transform.position.y - transform.position.y < -20)
        {
            transform.position += Vector3.down * playerscript.speed * Time.deltaTime;
        }
    }
}
