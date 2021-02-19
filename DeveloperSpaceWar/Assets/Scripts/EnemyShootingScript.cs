using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour
{

    [SerializeField] private EnemyBullet bulletPrefab;
    [SerializeField] private float forceBullet;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float recail;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    [SerializeField] private Vector2 direction;
    private bool isShooting;
    private bool inCamera;


    void Start() 
    {
        isShooting = false;
        inCamera = false;
    }

    void Update() 
    {
       Shot();
    }

    private void Shot()
    {
        
        if(isShooting == false && inCamera == true)
        {
            isShooting = true;
            var bullet = Instantiate(bulletPrefab,bulletSpawn.position, Quaternion.identity);
            bullet.SetImpulse(forceBullet, direction);
            audioSource.PlayOneShot(clip);
            StartCoroutine(RecailCoroutine());
        }
        
        
    }

    private void OnBecameVisible() 
    {
        inCamera = true;    
    }

    private void OnBecameInvisible() 
    {
        inCamera = false;
    }

    private IEnumerator RecailCoroutine()
    {
        yield return new WaitForSeconds(recail);
        isShooting = false;
        yield break;
    }
}
