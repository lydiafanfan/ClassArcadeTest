using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float lastSpawnTime = 0;
    public float spawnTime = 3000;

    //private Camera camera;
    GameObject leftSpawnMax;
    GameObject rightSpawnMax;

    public Transform enemyTarget;

    // Start is called before the first frame update
    void Start()
    {
        //camera = GetComponentInParent<Camera>();
        leftSpawnMax = new GameObject();
        rightSpawnMax = new GameObject();

        leftSpawnMax.transform.parent = transform;
        rightSpawnMax.transform.parent = transform;

        //leftSpawnMax.transform.position = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        //rightSpawnMax.transform.position = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, camera.nearClipPlane));
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > (lastSpawnTime + spawnTime)) {
            GameObject enemyObject = GameObject.Instantiate(enemyPrefab,new Vector3( 
                
                Random.Range(leftSpawnMax.transform.position.x, rightSpawnMax.transform.position.x)
                
                , transform.position.y, 0),Quaternion.identity);
            lastSpawnTime = Time.time;

            if(enemyObject != null)
            {
                Enemy enemyScript = enemyObject.GetComponent<Enemy>();
                if(enemyScript != null)
                {
                    enemyScript.SetLookTarget(enemyTarget);
                }
            }
        }
    }
}

