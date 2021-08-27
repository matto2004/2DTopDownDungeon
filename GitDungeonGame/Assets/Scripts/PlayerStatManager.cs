using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{

    private int health;
    private int damage;
    private int experience;
    private int level;
    public string charClass;

    public string CharClass { get => charClass; set => charClass = value; }
    public int Health { get => health; set => health = value; }
    public int Damage { get => damage; set => damage = value; }
    public int Experience { get => experience; set => experience = value; }
    public int Level { get => level; set => level = value; }

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
    
}
