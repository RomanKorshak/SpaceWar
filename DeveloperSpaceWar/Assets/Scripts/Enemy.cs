using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform startPosition;
    [SerializeField] private float recail;
    [SerializeField] private TurnTarget target;
    [SerializeField] private float bulletForce;
    private bool isShooting = false;
    
    

    void Update() 
    {
        Shot();
    }


    void Shot()
    {
        if(target.isTarget && !isShooting)
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
