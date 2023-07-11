using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthCounter : MonoBehaviour
{
    public GameObject[] hearts;
    public int health;
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health < 0)
        {
            health = 0;
        }
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}
