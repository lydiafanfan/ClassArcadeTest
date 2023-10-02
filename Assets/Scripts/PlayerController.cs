using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Animator anim;
    public float speed = 1;
    public GameObject laserPrefab;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        // If the xInput and yInput parameters on the Animator are set back to (0,0),
        // the Blend Tree will default back to the first Motion (PlayerStandDown).
        //  To prevent the player from always facing down when not moving, we simply
        //  don't set the animation parameters if both are 0, so the last values
        //  the animator sees are the last direction we moved.
        if(!(xInput == 0 && yInput == 0))
        {
            anim.SetFloat("xInput", xInput);
            anim.SetFloat("yInput", yInput);

            // Tell the animator that we are moving, so it can transition to the "Walk" blend tree
            anim.SetBool("isMoving",true);
        }
        else
        {
            // If xInput and yInput are both 0, we are no longer moving, so tell the animator
            anim.SetBool("isMoving",false);
        }

        body.AddForce(new Vector2(
            xInput * speed,
            yInput * speed
        ));

         if(Input.GetButtonDown("Fire1"))
        {
            GameObject laserObject = GameObject.Instantiate(laserPrefab, transform.position, Quaternion.identity);
            PlayerLaserController laserScript = laserObject.GetComponent<PlayerLaserController>();
            laserScript.SetRotation(transform.rotation);
        }
    }
}
