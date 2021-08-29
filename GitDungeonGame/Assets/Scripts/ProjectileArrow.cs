using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Room"))
        {
            Damage();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage();
            Destroy(gameObject);
        }
    }
    private void Damage()
    {
        var hitColliders = Physics2D.OverlapPointAll(transform.position);
        foreach (var hitCollider in hitColliders)
        {
            var enemy = hitCollider.GetComponent<Enemy>();
            if (enemy)
            {
                var closestPoint = hitCollider.ClosestPoint(transform.position);
                var distance = Vector3.Distance(closestPoint, transform.position);

                var damagePercent = 1;
                enemy.takeDamage(damagePercent * this.gameObject.GetComponent<ProjectileStats>().Damage);
                Debug.Log(this.gameObject.GetComponent<ProjectileStats>().Damage);
            }
        }
    }

}
