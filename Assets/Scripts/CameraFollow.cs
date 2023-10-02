using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 refVelocity;
    public float gameScreenWidth = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, target.position, ref refVelocity, smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(targetPosition.x,-gameScreenWidth,gameScreenWidth), 
            targetPosition.y, 
            -10
        );
        
        
        
        
        
    }
}
