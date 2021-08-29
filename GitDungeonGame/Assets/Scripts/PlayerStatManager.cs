using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{
    public Image healthBar;
    private float health = 100;
    private float damage = 10f;
    private int experience = 0;
    private int level = 1;
    private bool isInCombat;
    public string charClass;

    public float currenttime;
    private float timeDelay = 10;
    public string CharClass { get => charClass; set => charClass = value; }
    public float Damage { get => damage; set => damage = value; }
    public int Experience { get => experience; set => experience = value; }
    public int Level { get => level; set => level = value; }
    public float Health { get => health; set => health = value; }
    public bool IsInCombat { get => isInCombat; set => isInCombat = value; }
    public float Currenttime { get => Currenttime; set => Currenttime = value; }

    public void receiveDmg(float projectileDmg)
    {
        health = health - projectileDmg;
        currenttime = 0f;
    }

    public void receiveHealing(int healing)
    {
        health = health + healing;
    }

    public void setTime(float t)
    {
        currenttime = t;
    }
    public void Start()
    {
        charClass = MainMenu.Class;
    }
    public void Update()
    {
        currenttime = currenttime + 1f * Time.deltaTime;

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
