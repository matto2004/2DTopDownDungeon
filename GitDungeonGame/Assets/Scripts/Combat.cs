using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Combat : MonoBehaviour
{
    private PlayerStatManager stats;
    public SpriteRenderer spriteRenderer;

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
    public Animator playerAnimator;
    public Animator weaponAnimator;

    public float arrowForce = 0.5f;
    public float spellForce = 1f;
    private float charge = 0f;
    private readonly float maxCharge = 120f;
    private readonly float attackRange;
    private float time;
    private float timeDelay;

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
           // Rod.SetActive(true);
        }
        else
        {
            //Rod.SetActive(false);
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
        time += 1f * Time.deltaTime;

        if (SceneManager.GetActiveScene().buildIndex == 1) {
        if(stats.CharClass == "Warrior")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (time >= timeDelay)
                {
                    time = 0f;
                    Attack();
                }
            }
        }

        if (stats.CharClass == "Archer")
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (time >= timeDelay)
                {
                    time = 0f;
                    arrowForce = arrowForce + charge / 40;
                    ShootArrow();
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
    }
    private void FixedUpdate()
    {
        if (stats.CharClass == "Archer")
        {
            if (Input.GetButton("Fire1"))
            {
                if (charge < maxCharge)
                {
                    charge++;
                }
            }
        }
    }

    void ShootArrow()
    {
        GameObject bullet = Instantiate(bulletPrefab, ArcherfirePoint.position, ArcherfirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<ProjectileStats>().SetValues(stats.Damage * (charge/80)+5f);
        rb.AddForce(ArcherfirePoint.up * arrowForce, ForceMode2D.Impulse);
        charge = 0f;
        arrowForce = 0.5f;
        stats.SetTime(0f);
    }
    void ShootSpell()
    {
        playerAnimator.SetInteger("ShootState", 1);
        weaponAnimator.SetInteger("ShootState", 1);
        Vector3 lookDir = WizardfirePoint.rotation * Vector3.up;
        playerAnimator.SetFloat("HorizontalAim", lookDir.x);
        playerAnimator.SetFloat("VerticalAim", lookDir.y);
        weaponAnimator.SetFloat("HorizontalAim", lookDir.x);
        weaponAnimator.SetFloat("VerticalAim", lookDir.y);

        GameObject spell = Instantiate(spellPrefab, WizardfirePoint .position, WizardfirePoint.rotation);
        spell.GetComponent<ProjectileStats>().SetValues(stats.Damage);
        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        rb.AddForce(WizardfirePoint.up * spellForce, ForceMode2D.Impulse);
        stats.SetTime(0f);
        StartCoroutine(Wait(1f));
    }
    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);   //Wait
        playerAnimator.SetInteger("ShootState", 0);
        weaponAnimator.SetInteger("ShootState", 0);
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(WarriorfirePoint.transform.position, attackRange);
        stats.SetTime(0f);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<RangedEnemy>())
            {
                Debug.Log("hit" + enemy.name);
                enemy.GetComponent<RangedEnemy>().takeDamage(stats.Damage);
            }
            else if (enemy.GetComponent<MeleeEnemy>())
            {
                Debug.Log("hit" + enemy.name);
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
