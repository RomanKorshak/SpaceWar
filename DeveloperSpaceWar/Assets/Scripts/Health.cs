using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    
    public int HealthG
    {
        get => health;
        set
        {
            health = value;
        }
    }

    public void SetHealth(int bonus)
    {
        health += bonus;
    }

    public void Hit(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
