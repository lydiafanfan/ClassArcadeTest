using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speedBullet = 5f;
    public int damage = 10; 

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speedBullet * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitPlayer)
    {
        if (hitPlayer.CompareTag("Player"))
        {
            // decrease health
            PlayerMovement playerHealth = hitPlayer.GetComponent<PlayerMovement>();
            
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}

