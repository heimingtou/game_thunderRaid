using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
public class Enemy : MonoBehaviour
{
    public GameObject blood;// thanh mau
    protected float scaleHp; // do dai thanh mau
    public float speed;// toc do bay
    public float endPos; // vi tri dung bay
    protected bool isFly = true;
    public GameObject explosion;
    //protected float x;
    public GameObject bulletPrefab; // enemy_2_3
    public GameObject gun;// enemy_2_3
    protected float timer = 0f;// thoi gian cho dan enemy 1 //enemy_2_3
    protected bool startshoot = false;
    public float shootTime; // thoi gian ban cua enemy 1
    public bool flyRight = true;
    public float Maxhp = 5;
    public float hp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //baseBullet playerBullet = other.gameObject.GetComponent<baseBullet>();
        basePlayerBullet basePlayer=other.gameObject.GetComponent<basePlayerBullet>();
        if (basePlayer != null)
        {
            Debug.Log("va cham enemy");
            takeDamage(basePlayer.Damage);
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    virtual public void Awake()
    {
        hp = Maxhp;
        scaleHp = blood.transform.localScale.x;
    }
    void Start()
    {
        randomTimeShoot();
    }
    // Update is called once per frame
    void Update()
    {   
        if (isFly)
        {
            fly();
        }
        if (!startshoot)
        { return; }
            shoot();
    }
    // random thoi gian ban
    public void randomTimeShoot()
    {
        shootTime = UnityEngine.Random.Range(1f, 10f) * 2f;
        //Invoke("shoot2", shootTime);
    }
    public virtual void fly() // enemy bay vao khung hinh
    {
        if(flyRight)
       { transform.position += new Vector3(1 *speed * Time.deltaTime, 0, 0);
            if (transform.position.x > endPos)
            {
                isFly = false;
                startshoot = true;
            }
        }
        else
        {
            transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
            if (transform.position.x < endPos)
            {
                isFly = false;
                startshoot = true;
            }
        }
    }
    virtual public void shoot()
    {
        timer += Time.deltaTime;
        if (timer > shootTime)
        {
            Quaternion direction = Quaternion.Euler(0, 0, 180);
            Instantiate(bulletPrefab, gun.transform.position, direction);
            timer = 0;
        }
    }
    public void takeDamage(float damage)
    {
        hp -= damage;
        Vector3 scale= blood.transform.localScale;
        scale.x -= (scaleHp * damage / Maxhp);
        blood.transform.localScale = scale;
        if(hp<=0)
        {
            die();
        }
    }
    virtual public void  die()
    {
        if (UnityEngine.Random.Range(0, 10)%4 == 1)
            gameManager.instance.spawGif(this.gameObject.transform.position);
        saveManger.instance.addPoint();
        AudioManager.instance.playSFX(AudioManager.instance.explore, 0.5f);
        Instantiate(explosion, transform.position, quaternion.identity);
        //Debug.Log(gameManager.instance.score);
        Destroy(this.gameObject);
    }
}
