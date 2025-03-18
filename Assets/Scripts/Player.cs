using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float hMove;

    public GameObject bulletPrefab;

    public float fireRate = 0.5f, nextFire;
    UIManager uiManager;

    Rigidbody2D rb2d;
    public float bound = 7.5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.score = 0;
        uiManager.scoreText.text = uiManager.score.ToString();
        uiManager.hScore = PlayerPrefs.GetInt("HScore");
        uiManager.hScoreText.text = uiManager.hScore.ToString("000");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -bound, bound), transform.position.y);

        hMove = Input.GetAxisRaw("Horizontal");

        transform.Translate(hMove * speed * Time.deltaTime * Vector2.right);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time >= nextFire)
            Shoot();
    }


    private void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        nextFire = Time.time + fireRate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien") || collision.CompareTag("EnemyBullet"))
        {
            if (uiManager.score > uiManager.hScore)
            {
                PlayerPrefs.SetInt("HScore", uiManager.score);
                uiManager.hScoreText.text = uiManager.score.ToString();
                Debug.Log("Foi");
            }
            SceneManager.LoadScene(2);
        }
    }

}