using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySquid : MonoBehaviour
{
    private PlayerController player;
    public GameObject enemy;
    public GameObject enemyBullet;
    public GameObject enemyBulletClone;

    float enemySpeed = 0.25f;
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

        if (timer > timeToMove && numberOfMovements < 20)
        {
            transform.Translate(new Vector3(enemySpeed, 0, 0));
            timer = 0;
            numberOfMovements++;

            if (numberOfMovements == 20)
            {
                transform.Translate(new Vector3(0, -1f, 0));
                numberOfMovements = -1;
                enemySpeed = -enemySpeed;
                timer = 0;
            }
        }

        EnemyBullet();
    }

    void EnemyBullet()
    {
        if (Random.Range(0f, 500f) < 1)
        {
            enemyBulletClone = Instantiate(enemyBullet, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.4f, 0), enemy.transform.rotation) as GameObject;
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
