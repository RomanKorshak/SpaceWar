using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{

    [Header("Player Settings")]
    [SerializeField] private float speed;
    [SerializeField] private int damageValue;
    [SerializeField] private float bulletForce;
    [SerializeField] private float recail;
    [SerializeField] private Rigidbody2D playerBody;

    [Space]

    [Header("Bullet Settings")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform startPosition;
    public Transform StartPosition
    {
        get => startPosition;
    }
    [SerializeField] private CollisionDamage damage;

    [Space]

    [Header("Audio Settings")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip shotAudio;

    [Space]

    [Header("Shield Settings")]
    [SerializeField] private SpriteRenderer shield;

    [Space]

    [Header("Camera Settings")]
    [SerializeField] new private Camera camera;
    [SerializeField] private CameraEffect cameraShake;

    [Space]

    [SerializeField] private BuffReceiver buffReceiver;

    public bool isGod { get; set; }


    private Vector3 target;
    private float xRotation;
    private float yRotation;
    private float angle;
    private bool isShoot;

 

    private Vector2 direction = new Vector2(1,0);
    private Vector2 movement;


    void Start() 
    {
        damage.Damage = damageValue;    
        isGod = false;
        isShoot = false;
    }

    void Update() 
    {
        target = camera.ScreenToWorldPoint(Input.mousePosition) * Time.timeScale;

        xRotation = target.x - startPosition.transform.position.x;
        yRotation = target.y - startPosition.transform.position.y;

        angle = Mathf.Atan2(yRotation, xRotation) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f,0f,angle);


        if(Input.GetMouseButton(0) && Time.timeScale == 1 && !isShoot)
        {
            isShoot = true;
            Shot();
            StartCoroutine(RecailCoroutine());
        }

        CheckBuffs();
    }

    IEnumerator RecailCoroutine()
    {
        yield return new WaitForSeconds(recail);
        isShoot = false;
        yield break;
    }

    void FixedUpdate() 
    {
        if(playerBody == null)
        {
            playerBody = GetComponent<Rigidbody2D>();
        }

        float xRotation = Input.GetAxis("Horizontal");
        float yRotation = Input.GetAxis("Vertical");

        movement = new Vector2(xRotation, yRotation);

        playerBody.velocity = movement * speed;
    }

    void Shot()
    {
        direction = new Vector2(xRotation,yRotation);

        Bullet bullet = Instantiate(bulletPrefab, startPosition.transform.position,Quaternion.identity);
        bullet.gameObject.transform.position = startPosition.transform.position;
        bullet.SetImpulse(bulletForce,direction,this.gameObject);
        source.Play();
    }

    void CheckBuffs()
    {
        
        var buffs = buffReceiver.Buffs;
        for(int i = (buffs.Count - 1); i >= 0; i--)
        {
            if(buffs[i].type == TypeBuff.SpeedBuff)
            {
                speed += buffs[i].AdditiveBonus;
                StartCoroutine(BuffTimeCoroutine(buffs[i], buffs[i].AdditiveBonus));
                buffReceiver.RemoveBuff(buffs[i]);
            }
            else if(buffs[i].type == TypeBuff.DamageBuff)
            {
                damage.Damage += (int)buffs[i].AdditiveBonus;
                StartCoroutine(BuffTimeCoroutine(buffs[i],buffs[i].AdditiveBonus));
                buffReceiver.RemoveBuff(buffs[i]);
            }
            else if(buffs[i].type == TypeBuff.ShieldBuff)
            {
                shield.gameObject.SetActive(true);
                isGod = true;
                StartCoroutine(BuffTimeCoroutine(buffs[i],buffs[i].AdditiveBonus));
                buffReceiver.RemoveBuff(buffs[i]);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.gameObject.CompareTag("Coin"))
        {
            PlayerInventory.Instance.AddCoin();
            Destroy(other.gameObject);
            return;
        }
        
        if(isGod)
        {
           
            var bull = other.gameObject.GetComponent<Bullet>();
            if(bull != null)
            {
                if(bull.parent = gameObject)
                    return;
            }
            if(other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Radar"))
                return;
            Destroy(other.gameObject);
            return;
        }
        if(other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("BonusBox") || other.gameObject.CompareTag("Radar"))
        {
            return;
        }
       
        cameraShake.Shake();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(isGod)
        {
            if(other.gameObject.CompareTag("Block"))
                return;
            Destroy(other.gameObject);
            return;
        }
        if(other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("BonusBox") || other.gameObject.CompareTag("Radar"))
        {
            return;
        }
        cameraShake.Shake();
    }
    
    IEnumerator BuffTimeCoroutine(Buff buff,float bonus)
    {
        yield return new WaitForSeconds(buff.Seconds);
        if(buff.type == TypeBuff.SpeedBuff)
            speed -= bonus;
        if(buff.type == TypeBuff.DamageBuff)
            damage.Damage -= (int)bonus;
        if(buff.type == TypeBuff.ShieldBuff)
        {
            shield.gameObject.SetActive(false);
            isGod = false;
        }
        yield break;
    }
}
