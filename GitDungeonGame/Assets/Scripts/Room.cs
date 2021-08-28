using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public GameObject MeeleEnemy;
    public GameObject RangedEnemy;
    private float randPosx;
    private float randPosy;
    private int randAmount;
    private int randEnemy;
    private Random rand = new Random();
    public GameObject[] EnemysInThisRoom;


    void Start()
    {
        
        randAmount = Random.Range(1, 5);
        EnemysInThisRoom = new GameObject[randAmount];

        for(int i = 0; i < randAmount; i++)
        {
            randPosx = Random.Range(0f, 2f);
            randPosy = Random.Range(0f, 2f);
            randEnemy = Random.Range(1, 3);
            if (randEnemy == 1)
            {
                GameObject MEnemy = Instantiate(MeeleEnemy, new Vector2(transform.position.x + randPosx, transform.position.y + randPosy), Quaternion.identity);
                EnemysInThisRoom[i] = MEnemy;
            }
            if (randEnemy == 2)
            {
                GameObject REnemy = Instantiate(RangedEnemy, new Vector2(transform.position.x + randPosx, transform.position.y + randPosy), Quaternion.identity);
                EnemysInThisRoom[i] = REnemy;
            }
        }
    }





    
   
}
