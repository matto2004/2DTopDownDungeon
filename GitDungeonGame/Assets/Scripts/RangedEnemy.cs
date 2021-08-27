﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public float speed;
    public int damage;
    public int health;


    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;


    public GameObject xProjectile;
    public Transform player;
    private Rigidbody2D rb;
    public Transform FirePoint;

    void Start()
    {
        damage = 5;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Die();

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            Shot();
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
       
    }
    
    public void Shot()
    {
        ProjectileStats projectile = Instantiate(xProjectile, transform.position, FirePoint.rotation).GetComponent<ProjectileStats>();
        projectile.SetValues(damage);
    }

    public void takeDamage(int d)
    {
        health = health - d;
    }


    public void Die()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
