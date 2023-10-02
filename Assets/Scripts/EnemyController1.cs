using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1 : Enemy
{
    private Rigidbody2D body;
    public float movespeed = 1;
    public float lookOffset = 0;
    public float rotateSpeed = 1;

    private Vector3 startPosition;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        body = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        StartCoroutine(WaitToAttack());
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();

        // body.velocity += new Vector2(0, -movespeed * Time.deltaTime);


        Vector3 lookDirection = lookTarget.position - transform.position;

        float lookAngle = (Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg) + lookOffset;

        Quaternion targetAngle = Quaternion.Euler( 0, 0, lookAngle );

        transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, rotateSpeed * Time.deltaTime );

        transform.Translate( Vector3.down * movespeed * Time.deltaTime, Space.Self );


        if(Vector3.Distance(transform.position,startPosition) > 999) {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator WaitToAttack() {
        yield return new WaitForSeconds(1);
        Debug.Log("Shoot!");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Shoot again!");
        StartCoroutine(WaitToAttack());
    }
}
