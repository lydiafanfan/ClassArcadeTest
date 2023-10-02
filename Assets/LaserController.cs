using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    
    void OnTriggerEnter2D (Collider2D hit) 
    {
        Enemy enemy = hit.GetComponent<Enemy>();
        if(enemy != null){
            enemy.TakeDamage(30);
        }
        //Debug.Log(hit.name);
        Destroy(gameObject);
        
    }

}
