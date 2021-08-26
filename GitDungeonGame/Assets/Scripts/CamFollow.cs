using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followSpeed = 10f;
    void Update()
    {
        transform.position = target.position + offset;   
    }
}
