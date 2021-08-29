﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private PlayerStatManager stats;

    public Transform ArcherfirePoint;
    public GameObject WarriorfirePoint;
    public Transform WizardfirePoint;
    public GameObject bulletPrefab;
    public GameObject spellPrefab;
    public GameObject Bow;
    public GameObject Rod;
    public GameObject Sword;
    public Sprite Warrior;
    public Sprite Wizard;
    public Sprite Archer;

    public float arrowForce = 0.5f;
    public float spellForce = 1f;
    public float charge = 0f;
    public float attackRange;
    public LayerMask whatIsEnemies;
    float time;
    float timeDelay;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatManager>();
        time = 1f;
        timeDelay = 1f;
    }

    public void spriteChanger()
    {
        if(stats.charClass == "Archer")
        {
            spriteRenderer.sprite = Archer;
            Bow.SetActive(true);
            
        }
        else
        {
            Bow.SetActive(false);
        }
        if (stats.charClass == "Wizard")
        {
            spriteRenderer.sprite = Wizard;
            Rod.SetActive(true);
        }
        else
        {
            Rod.SetActive(false);
        }
        if (stats.charClass == "Warrior")
        {
            spriteRenderer.sprite = Warrior;
            Sword.SetActive(true);
        }
        else
        {
            Sword.SetActive(false);
        }

        
    }

    private void Update() 
    {
        spriteChanger();

        
        if(stats.CharClass == "Warrior")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if(time >= timeDelay)
                {
                    Attack();
                }
            }
        }

        time = time + 1f * Time.deltaTime;
        if (stats.CharClass == "Archer")
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (time >= timeDelay)
                {
                    time = 0f;
                    arrowForce = arrowForce + charge / 40;
                    Shoot();
                }
            }
        }
        if (stats.CharClass == "Wizard")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (time >= timeDelay)
                {
                    time = 0f;
                    ShootSpell();
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (stats.CharClass == "Archer")
        {
            if (Input.GetButton("Fire1"))
            {
                if (charge < 240)
                {
                    charge = charge + 1;
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, ArcherfirePoint.position, ArcherfirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(ArcherfirePoint.up * arrowForce, ForceMode2D.Impulse);
        charge = 0f;
        arrowForce = 0.5f;
    }
    void ShootSpell()
    {
        GameObject spell = Instantiate(spellPrefab, WizardfirePoint .position, WizardfirePoint.rotation);
        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        rb.AddForce(WizardfirePoint.up * spellForce, ForceMode2D.Impulse);
    }
    
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(WarriorfirePoint.transform.position, attackRange, whatIsEnemies);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<RangedEnemy>())
            {
                enemy.GetComponent<RangedEnemy>().takeDamage(stats.Damage);
            }
            else if (enemy.GetComponent<MeleeEnemy>())
            {
                enemy.GetComponent<MeleeEnemy>().takeDamage(stats.Damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {

        if(WarriorfirePoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(WarriorfirePoint.transform.position,attackRange);
    }
}