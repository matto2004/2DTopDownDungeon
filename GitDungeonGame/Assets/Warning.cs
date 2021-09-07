using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Off", 2,2);
    }

    
    public void Off()
    {
        gameObject.SetActive(false);
    }
}
