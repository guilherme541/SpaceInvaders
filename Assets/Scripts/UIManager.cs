using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText, hScoreText;
    public int score, hScore;
    
    private void Awake()
    {
        UpdateScoreText();
    }

    public void UpdateScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString("000");
    }
}
