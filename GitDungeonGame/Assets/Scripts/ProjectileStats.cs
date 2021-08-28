using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStats : MonoBehaviour
{
    private float damage;

    public float Damage { get => damage; set => damage = value; }

    public void SetValues(float d)
    {
        this.damage = d;
    }
}
