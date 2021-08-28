using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public float stoppingDistance;
    public float retreatDistance;
    

    private float timeBtwShots;
    public float startTimeBtwShots;


    public GameObject xProjectile;
    public Transform player;
    private Rigidbody2D rb;
    public Transform FirePoint;

    private Ray2D ray;
    

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

        ray = new Ray2D(new Vector2(transform.position.x,transform.position.y),new Vector2(player.position.x,player.position.y));
        RaycastHit hit;
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            {
                { if(true)//Can See Player
       
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                }
            }
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            if (true)//Can See Player
            { 
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
        }

        if (timeBtwShots <= 0 && Vector2.Distance(transform.position,player.position) <=stoppingDistance)
        {
            Shot();
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }

    bool CanSeePlayer()
    {
        bool val = false;

        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.position,1<<LayerMask.NameToLayer("Action"));

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
        }
        return val;
    }
   


    public void Shot()
    {
        ProjectileStats projectile = Instantiate(xProjectile, transform.position, FirePoint.rotation).GetComponent<ProjectileStats>();
        projectile.SetValues(damage);
    }

}
