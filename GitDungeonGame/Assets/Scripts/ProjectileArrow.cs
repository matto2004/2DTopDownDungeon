using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Room"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<PlayerStatManager>().receiveDmg(damage);
            Destroy(gameObject);
        }
    }
}
