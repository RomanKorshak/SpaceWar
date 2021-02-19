using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private Health health;
    [SerializeField] private float recail;

    [Space]

    [Header("Bullet Settings")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform startPosition;
    [SerializeField] private TurnTarget target;
    [SerializeField] private float bulletForce;

    [Space]

    [Header("Audio Settings")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clipShot;

    [Space]
    
    private bool isShooting = false;

    public bool IsShooting
    {
        get => isShooting;
        set
        {
            isShooting = value;
        }
    }
    
    
    void Update() 
    {
        Shot();
    }

    void Shot()
    {
        if(health.HealthG <= 0)
            return;

        if(target.isTarget && !isShooting)
        {
            
            var bullet = Instantiate(bulletPrefab,startPosition.transform.position, Quaternion.identity);
            bullet.SetImpulse(bulletForce,new Vector2(target.xRotation, target.yRotation),this.gameObject);
            source.PlayOneShot(clipShot);
            isShooting = true;
            StartCoroutine(Recail());
        }
    }

    private IEnumerator Recail()
    {
        yield return new WaitForSeconds(recail);
        isShooting = false;
        yield break;
    }
}
