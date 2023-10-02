using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector3 startPosition;
    public Transform target;
    public float factor;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = startPosition + ((target.position - startPosition) * factor);
    }
}
