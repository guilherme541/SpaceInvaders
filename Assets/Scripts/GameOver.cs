using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // public TextMeshProUGUI scoreText;

    void Start()
    {

    }

    // private void Awake()
    // {
    //     int score = PlayerPrefs.GetInt("Score", 0);
    //     scoreText.text = score.ToString();
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }

    }
}
