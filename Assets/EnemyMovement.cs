using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float stopingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject bullet;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        //check the distance between the enemy and player
        if (Vector2.Distance(transform.position, player.position) > stopingDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime); //move closer
        }
        else if (Vector2.Distance(transform.position, player.position) < stopingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance){
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position)< retreatDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed*Time.deltaTime);
        }


        if (timeBtwShots <= 0){
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        } else {
            timeBtwShots -= Time.deltaTime;
        }
    }    
}

