using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorHitDetector : MonoBehaviour
{
    PlayerStatManager stats;
    private Collider2D col;

    public Collider2D Col { get => col; set => col = value; }

    public void Start()
    {
       stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatManager>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        col = collision;
    }
}
