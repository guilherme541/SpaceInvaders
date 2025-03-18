using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienArea : MonoBehaviour
{

    Vector2 direction = Vector2.right;
    public float speed = 1f;
    public Alien[] aliens;
    public int rows = 5, columns = 11;
    int amountDead = 0;
    const int totalAliens = 45;
    public GameObject missilePrefab;
    public float shootTimer = 3f;
    const float shootTime = 3f;
    public List<GameObject> allAliens = new List<GameObject>();
    public GameObject ShipPrefab;
    Vector2 ShipSpawnPos = new Vector2(16.3f, 13.0f);
    UIManager uiManager;

    void Start()
    {
        foreach (GameObject alien in GameObject.FindGameObjectsWithTag("Alien")) allAliens.Add(alien);
        uiManager = FindObjectOfType<UIManager>();
        InvokeRepeating(nameof(SpawnShip), 10, UnityEngine.Random.Range(10, 20));
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(direction * speed * Time.deltaTime);

        // Vector2 leftEdge = Camera.main.ViewportToWorldPoint(Vector2.zero);
        // Vector2 rightEdge = Camera.main.ViewportToWorldPoint(Vector2.right);

        Vector2 leftEdge = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 rightEdge = Camera.main.ViewportToWorldPoint(Vector2.right);

        foreach (Transform Alien in transform)
        {
            if (direction == Vector2.right && Alien.position.x >= 4) AdvanceAlien();
            else if (direction == Vector2.left && Alien.position.x <= -4) AdvanceAlien();

        }

        if (shootTimer <= 0)
            EnemyShoot();

        shootTimer -= Time.deltaTime;

    }


    void AdvanceAlien()
    {
        direction.x *= -1;
        Vector3 position = transform.position;
        position.y -= 0.2f;
        transform.position = position;
    }

    private void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Alien alien =
                Instantiate(aliens[row], transform);

                Vector2 center = new Vector2(-4.5f, 1);
                Vector2 rowPosition = new Vector2(center.x, center.y + (row * 0.8f));
                Vector2 position = rowPosition;
                position.x += col * 0.8f;
                alien.transform.localPosition = position;
            }
        }
    }

    private void EnemyShoot()
    {
        Vector2 pos = allAliens[UnityEngine.Random.Range(0, allAliens.Count)].transform.position;
        Instantiate(missilePrefab, pos, Quaternion.identity);
        shootTimer = shootTime;
    }


    void SpawnShip()
    {
        Instantiate(ShipPrefab, new Vector2(4.6f, 4.5f), Quaternion.identity);
    }

    public void AlienKilled()
    {
        amountDead++;
        speed += 0.05f;

        if (speed >= 5) speed = 5;

        if (amountDead >= totalAliens)
        {
            if (uiManager.score > uiManager.hScore)
            {
                PlayerPrefs.SetInt("HScore", uiManager.score);
                uiManager.hScoreText.text = uiManager.score.ToString();
            }
            SceneManager.LoadScene(1);
        }
    }

}