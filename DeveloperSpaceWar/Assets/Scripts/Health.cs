using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private DestroyEffect particleEffect;
    
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
        if(Player.Instance.isGod && gameObject == Player.Instance.gameObject)
        {
            return;
        }
        health -= damage;
        if(health <= 0)
        {
            if(particleEffect != null)
            {
                StartCoroutine(particleEffect.DestroyEffectCoroutine(gameObject));
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}
