using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private PlayerStatManager stats;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject spellPrefab;
    public GameObject Bow;
    public GameObject Rod;
    public GameObject Sword;
    public Sprite Warrior;
    public Sprite Wizard;
    public Sprite Archer;
    public int type; //1 Nahkampf 2 Bogen 3 Spell

    public float arrowForce = 0.5f;
    public float spellForce = 1f;
    public float charge = 0f;
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
        charge = 0f;
        arrowForce = 0.5f;
    }
    void ShootSpell()
    {
        GameObject spell = Instantiate(spellPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * spellForce, ForceMode2D.Impulse);
    }
}
