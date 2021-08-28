using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorHitDetector : MonoBehaviour
{
    PlayerStatManager stats;
    public void Start()
    {
       stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatManager>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MeleeEnemy>())
        {
            collision.gameObject.GetComponent<MeleeEnemy>().takeDamage(stats.Damage);
        }
        if (collision.gameObject.GetComponent<RangedEnemy>())
        {
            collision.gameObject.GetComponent<RangedEnemy>().takeDamage(stats.Damage);
        }
    }
}
