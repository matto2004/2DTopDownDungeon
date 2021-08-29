using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{


    private Rigidbody2D rb;
    public Transform player;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Die();
        Vector2 direction = new Vector2(player.position.x, player.position.y)- new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 4f);
        if (hit)
        {
            if (hit.collider.name == "Player")
            {
                Vector3 direction1 = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
                rb.rotation = angle;
                if (Vector2.Distance(transform.position, player.position) > 0.33)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
            }
        }
    }

}
