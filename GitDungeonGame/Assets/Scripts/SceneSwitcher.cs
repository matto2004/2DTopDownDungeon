using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public GameObject Player;
    public void ChangeFromDungeonToVillage()
    {
        if (Player.GetComponent<PlayerStatManager>().IsInCombat == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    public void ChangeFromVillageToDungeon()
    {  
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

}
