using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D playerBody;

    public GameObject sword;

    float countdown = 5;
    public float swingTime = 0.45f;
    public float swingCool = 1.5f;
    public float speed;
    public float xdirection;
    public float ydirection;

    //cooldown
    float cooldown()
    {
        countdown += Time.deltaTime;
        return countdown;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        xdirection = 1;
        ydirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown() > swingTime)
        {
            speed = 25;
        }
        //movement
        if (Input.GetKey(KeyCode.W) == true)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            ydirection = 1;
            xdirection = 0;
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            ydirection = -1;
            xdirection = 0;
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            xdirection = -1;
            ydirection = 0;
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            xdirection = 1;
            ydirection = 0;
        }

        //sword
        if (Input.GetKey(KeyCode.Space) == true)
        {
            if (cooldown() > swingCool)
            {
                Instantiate(sword, transform.position + new Vector3(7.8f * xdirection, 7.8f * ydirection, 0), new Quaternion(0f, 0f, xdirection * 1f, 1f));
                countdown = 0;
                speed = 0;
            }
        }
        else
        {
            cooldown();
        }
    }
}
