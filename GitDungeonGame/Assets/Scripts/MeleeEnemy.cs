using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{


    private Transform target;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Die();
        var ray = new Ray(this.transform.position, target.position);
        RaycastHit hit;
        if (Vector2.Distance(transform.position, target.position) > 0.3)
        {
            
            if (Physics.Raycast(ray, out hit))
            {
                
                GameObject LastHit = hit.transform.gameObject;

                if(LastHit.transform.gameObject.tag != "Player")
                {
                    return;
                }
                if (LastHit.CompareTag("Player"))
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                }
            }
        }
    }

}
