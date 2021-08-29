using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float speed;

    private Transform player;
    private Vector2 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
        Destroy(gameObject, 2);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Room"))
        {
            Destroy(gameObject);
        }
        if (collision.GetComponent<PlayerStatManager>())
        {
            float d = gameObject.GetComponent<ProjectileStats>().Damage;
            collision.GetComponent<PlayerStatManager>().ReceiveDmg(d);
            Destroy(gameObject);
        }
    }


}
