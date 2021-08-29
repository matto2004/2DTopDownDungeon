using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Room"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().takeDamage(this.gameObject.GetComponent<ProjectileStats>().Damage);
            Destroy(gameObject);
        }
    }
}
