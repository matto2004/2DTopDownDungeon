using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(gameObject);       
    }

    public string Name;

    public Image healthBar;
    private float health = 100;
    private float damage = 10f;
    private int experience = 0;
    private int level = 1;
    private bool isInCombat;

    public string charClass;
    public int charNum;

    public int character;
    public Animator playerAnimator;
    public Animator rodAnimator;

    public float currenttime;
    private readonly float timeDelay = 10;
    public string CharClass { get => charClass; set => charClass = value; }
    public int Character { get => character; set => character = value; }
    public float Damage { get => damage; set => damage = value; }
    public int Experience { get => experience; set => experience = value; }
    public int Level { get => level; set => level = value; }
    public float Health { get => health; set => health = value; }
    public bool IsInCombat { get => isInCombat; set => isInCombat = value; }
    public float Currenttime { get => Currenttime; set => Currenttime = value; }
    public int CharNum { get => charNum; set => charNum = value; }

    public void ReceiveDmg(float projectileDmg)
    {
        health -= projectileDmg;
        currenttime = 0f;
    }

    public void ReceiveHealing(int healing)
    {
        health += healing;
    }

    public void SetTime(float t)
    {
        currenttime = t;
    }

    
   
    public void Update()
    {
        currenttime += 1f * Time.deltaTime;
        playerAnimator.SetInteger("Character", this.Character);
        rodAnimator.SetInteger("Character", this.Character);

        if(currenttime >= timeDelay)
        {
            isInCombat = false;
        }
        else
        {
            isInCombat = true;
        }
        healthBar.fillAmount = health / 100 ; 

    }

}
