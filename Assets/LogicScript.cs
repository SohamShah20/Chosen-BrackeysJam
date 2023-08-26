using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int playerHealth;

    public Text healthText;
    public Text scoreText;
    public PlayerScript player;

    public void increaseScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }

}
