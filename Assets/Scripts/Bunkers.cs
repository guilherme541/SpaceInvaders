using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunkers : MonoBehaviour
{
    public Color[] states;
    int health;
    SpriteRenderer sr;
    void Start()
    {
        health = 3;
        sr = GetComponent<SpriteRenderer>();
        states = new Color[] { Color.red, new Color(1f, 0.5f, 0f), Color.yellow };
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Alien>().DestroyAlien();
        }

        if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            health--;

            if (health < 0){
                Destroy(gameObject);
            }
            else
            {
                sr.color = states[health];
            }
        }

        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }

}