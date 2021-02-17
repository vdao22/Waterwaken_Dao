using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyJellyfish : MonoBehaviour
{
    private PlayerController player;

    float enemySpeed = 0.8f;
    float timer = 0;
    float timeToMove = 0.5f;
    float numberOfMovements = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeToMove && numberOfMovements < 200)
        {
            transform.Translate(new Vector3(0, -enemySpeed, 0));
            timer = 0;
            numberOfMovements++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Die();
        }

        if (collision.gameObject.tag == "DestroyEnemyBullet")
        {
            SceneManager.LoadScene("Restart");
        }
    }
}
