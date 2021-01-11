using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text playerLivesText;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetScoreText(0);
        SetPlayerLivesText(0);
    }

    public void SetScoreText(int _score)
    {
        score += _score;
        scoreText.text = "Score " + score;
    }

    public void SetPlayerLivesText(int _lives)
    {
        playerLivesText.text = "Lives " + _lives;
    }
}
