using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserController : MonoBehaviour
{
    private Rigidbody2D body;
    public float movespeed = 1;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        body.velocity += new Vector2(0, movespeed * Time.deltaTime);

        if(Vector3.Distance(transform.position,startPosition) > 999) {
            Destroy(this.gameObject);
        }
    }
}
