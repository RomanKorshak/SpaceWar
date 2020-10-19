using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform startPosition;
    [SerializeField] private float recail;
    [SerializeField] private TurnTarget target;
    [SerializeField] private float bulletForce;
    private bool isShooting = false;
    private bool isTarget = false;
    

    void Update() 
    {
        Shot();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isTarget = true;
           
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isTarget = false;
        }    
    }

    void Shot()
    {
        if(isTarget && !isShooting)
        {
            var bullet = Instantiate(bulletPrefab,startPosition.transform.position, Quaternion.identity);
            bullet.SetImpulse(bulletForce,new Vector2(target.xRotation, target.yRotation),this.gameObject);
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
