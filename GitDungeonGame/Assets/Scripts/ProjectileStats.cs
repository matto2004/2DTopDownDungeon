using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStats : MonoBehaviour
{
    private int damage;

    public int Damage { get => damage; set => damage = value; }

    public void SetValues(int d)
    {
        this.damage = d;
    }
}
