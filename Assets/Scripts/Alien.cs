using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alien : MonoBehaviour
{

    public GameObject explosionPrefab;
    AlienArea alienArea;
    UIManager uiManager;
    public int scoreValue;

    void Start()
    {
        alienArea = FindObjectOfType<AlienArea>();
        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyAlien()
    {
        FindObjectOfType<UIManager>().UpdateScore(scoreValue);
        alienArea.allAliens.Remove(gameObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        alienArea.AlienKilled();
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            if (uiManager.score > uiManager.hScore)
            {
                PlayerPrefs.SetInt("HScore", uiManager.score);
                uiManager.hScoreText.text = uiManager.score.ToString();
            }
            SceneManager.LoadScene(2);
        }
    }

}
