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
        Vector2 direction = new Vector2(target.position.x, target.position.y)- new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 4f);
        if (hit)
        {
            if (hit.collider.name == "Player")
            {
                if (Vector2.Distance(transform.position, target.position) > 0.3)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
            }
        }
    }

}
