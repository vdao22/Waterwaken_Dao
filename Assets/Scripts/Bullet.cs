using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    private Score score;
    public GameObject bullet;
    public float bulletSpeed = -5;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -bulletSpeed * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SoundManagerScript.PlaySound("enemyexplode");
            score.AddScore(10);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(bullet);
        }

        if (collision.gameObject.tag == "DestroyPlayerBullet")
        {
            Destroy(bullet);
        }
    }
}


