using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject kamera;
    private SpriteRenderer _spriteRenderer;
    public LogicScript logic;
    public PlayerScript player;

    int coinType;

    // Start is called before the first frame update
    void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        coinType = Random.Range(1, 11);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (coinType == 1)
        {
            Destroy(gameObject);
        }
        if (coinType == 8 || coinType == 9)
        {
            _spriteRenderer.color = Color.green;
        }
        if (coinType == 10)
        {
            _spriteRenderer.color = Color.red;
        }
        if (coinType == 6 || coinType == 7)
        {
            _spriteRenderer.color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (kamera.transform.position.y - transform.position.y > 500 || kamera.transform.position.y - transform.position.y < -500)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (coinType == 8 || coinType == 9)
        {
            player.trueSpeed += 5;
        }
        else if (coinType == 6 || coinType == 7)
        {
            logic.useBullets(-5);
        }
        else if (coinType == 10)
        {
            logic.reduceHealth(-10);
        }
        else
        {
            logic.increaseScore(100);
        }
        Destroy(gameObject);
    }
}
