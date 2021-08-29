using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : MonoBehaviour
{
    public float splashRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Room"))
        {
            SplashDamage();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            SplashDamage();
            Destroy(gameObject);
        }
    }
    private void SplashDamage()
    {
        var hitColliders = Physics2D.OverlapCircleAll(transform.position, splashRange);
        foreach(var hitCollider in hitColliders)
        {
            var enemy = hitCollider.GetComponent<Enemy>();
            if (enemy)
            {
                var closestPoint = hitCollider.ClosestPoint(transform.position);
                var distance = Vector3.Distance(closestPoint, transform.position);

                var damagePercent = Mathf.InverseLerp(splashRange, 0, distance);
                enemy.takeDamage(damagePercent * this.gameObject.GetComponent<ProjectileStats>().Damage);
            }
        }
    }
}
