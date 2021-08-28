using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float damage;
    public float health;

    public void takeDamage(float d)
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
