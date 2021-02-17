using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    private PlayerController player;
    public GameObject enemyBullet;
    public float bulletSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -bulletSpeed * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Damage(1);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(enemyBullet);
        }

        if (collision.gameObject.tag == "DestroyEnemyBullet")
        {
            Destroy(enemyBullet);
        }
    }
}
