using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int playerHealth;
    public int bullets;
    public int depth;
    public int maxDepth;
    public bool scorePlus = false;

    public Text healthText;
    public Text scoreText;
    public Text depthText;
    public Text bulletsLeftText;
    public PlayerScript player;
    public EnemyScript enemy;
    public bullet1Script enemyBullet;

    public void increaseScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }

    public void reduceHealth(int damage)
    {
        playerHealth -= damage;
        healthText.text = playerHealth.ToString();
    }

    public void raiseDifficulty(float difficulty)
    {
        enemy.enemy1Speed += 20 * difficulty;
        enemyBullet.bullet1Speed += 20 * difficulty;
        enemy.shootFreq /= difficulty * 4;
        enemy.scoreIncrease += (int) (100 * difficulty);
    }

    public void useBullets(int amount)
    {
        bullets -= amount;
        bulletsLeftText.text = bullets.ToString();
    }

    void Start()
    {
        enemyBullet.bullet1Speed = 50;
    }

    void Update()
    {
        //increase depth and keep track of maxDepth
        depth = player.depthCheck();
        if (depth > maxDepth)
        {
            maxDepth = depth;
        }
        depthText.text = depth.ToString();

        //Every 25 depth increase score and difficulty
        if (maxDepth % 25 == 0)
        {
            if (scorePlus == true)
            {
                increaseScore(25);
                raiseDifficulty(0.25f);
                scorePlus = false;
            }
        }
        else
        {
            scorePlus = true;
        }
    }

}
