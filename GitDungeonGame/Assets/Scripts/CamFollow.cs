using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;
    public float lerpSpeed = 1.0f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;        
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpSpeed * Time.deltaTime);

    }
}
