using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject spellPrefab;
    public int type; //1 Nahkampf 2 Bogen 3 Spell

    public float arrowForce = 5f;
    public float spellForce = 10f;
    public float charge = 0f;

    private void Update()
    {
        if (type == 2)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                arrowForce = arrowForce + charge / 20;
                Shoot();
            }
        }
        if (type == 3)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootSpell();
            }
        }
    }
    private void FixedUpdate()
    {
        if (type == 2)
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
        charge = 0f;
        arrowForce = 5f;
    }
    void ShootSpell()
    {
        GameObject spell = Instantiate(spellPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * spellForce, ForceMode2D.Impulse);
    }
