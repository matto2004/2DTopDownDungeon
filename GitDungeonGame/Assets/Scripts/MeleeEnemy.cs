using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float speed;
    public int damage;
    public int health;

    private Transform target;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Die();
     
        if (Vector2.Distance(transform.position, target.position) > 0.3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void takeDamage(int d)
    {
        health = health - d;
    }

    public void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
