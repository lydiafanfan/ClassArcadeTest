using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float lastSpawnTime = 0;
    public float spawnTime = 3000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > (lastSpawnTime + spawnTime)) {
            GameObject.Instantiate(enemyPrefab,new Vector3( 
                
                Random.Range(transform.position.x-10, transform.position.x + 10)
                
                , transform.position.y, 0),Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}

