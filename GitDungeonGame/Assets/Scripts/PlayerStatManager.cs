﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{
    public Image healthBar;

    private float health = 100;
    private int damage = 10;
    private int experience = 0;
    private int level = 1;
    public string charClass;

    public string CharClass { get => charClass; set => charClass = value; }
    public int Damage { get => damage; set => damage = value; }
    public int Experience { get => experience; set => experience = value; }
    public int Level { get => level; set => level = value; }
    public float Health { get => health; set => health = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void receiveDmg(int projectileDmg)
    {
        health = health - projectileDmg;
    }

    public void receiveHealing(int healing)
    {
        health = health + healing;
    }

    public void Update()
    {
        healthBar.fillAmount = health / 100 ; 
    }

}
