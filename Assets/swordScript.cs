using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    float countdown = 0;

    public GameObject player;
    public PlayerScript playerscript;

    //cooldown
    float cooldown()
    {
        countdown += Time.deltaTime;
        return countdown;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown() > 0.45)
        {
            Destroy(gameObject);
        }
    }
}