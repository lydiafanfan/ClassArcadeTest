using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
  public Transform shootPoint;
  public GameObject laserPrefab;
  public float speed = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

void Shoot(){
    //creating 
    GameObject laser = Instantiate(laserPrefab, shootPoint.position, shootPoint.rotation);
    Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
    //add speed
    rb.AddForce(shootPoint.up*speed, ForceMode2D.Impulse);


}

}
