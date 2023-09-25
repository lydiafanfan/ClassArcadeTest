using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    public float movespeed = 1;
    public GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        body.AddForce(new Vector3(xInput,yInput,0) * movespeed);

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject.Instantiate(laserPrefab, transform.position, Quaternion.identity);
        }
    }
}
