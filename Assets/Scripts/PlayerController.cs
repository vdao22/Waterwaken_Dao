using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public KeyCode Right, Left, Up, Down;
    public GameObject player;
    public GameObject playerBullet;
    public GameObject playerBulletClone;
    public float speed = 5;
    public int currentHealth;
    public int maxHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Update player health
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        // When player loses all of health, player dies
        if (currentHealth <= 0)
        {
            Die();
        }

        Movement();
        Shoot();
    }

    void Movement()
    {
        // Player movement controls
        if (Input.GetKey(Right))
        {
            rb.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(Left))
        {
            rb.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(Up))
        {
            rb.transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }

        if (Input.GetKey(Down))
        {
            rb.transform.Translate(new Vector2(0, -speed * Time.deltaTime));
        }
    }

    void Shoot()
    {
        // Player only allowed to have one active bullet at any moment
        if (Input.GetKeyDown(KeyCode.Space) && playerBulletClone == null)
        {
            playerBulletClone = Instantiate(playerBullet, new Vector3(player.transform.position.x, player.transform.position.y + 0.65f, 0), player.transform.rotation) as GameObject;
        }
    }

    public void Damage(int dmg)
    {
        SoundManagerScript.PlaySound("playertakedmg");
        currentHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("DamageFlash");
    }

    // Leads to restart scene
    public void Die()
    {
        SceneManager.LoadScene("Restart");
    }
}
