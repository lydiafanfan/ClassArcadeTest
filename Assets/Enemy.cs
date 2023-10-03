using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public static int totalEnemies = 3; 

    public int health = 260;


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            CheckWin();
        }
    }

    void CheckWin()
    {
        totalEnemies--;
        Debug.Log("died test");

        if (totalEnemies <= 0)
        {
            
            SceneManager.LoadScene("WinScreen"); 
        }
    }
}

   
