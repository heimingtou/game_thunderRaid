using DG.Tweening;
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
    //public Vector3 endPos; // vi tri dung bay
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
            //Debug.Log("va cham enemy");
            takeDamage(basePlayer.Damage);
            other.gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        // Lệnh này giết chết TOÀN BỘ Tween đang dính trên người con Enemy này
        transform.DOKill();
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
    public virtual void FlyToPosition(Vector3 endPos)
    {
        // 1. Tính toán thời gian bay dựa trên tốc độ và khoảng cách
        // Công thức: Thời gian = Quãng đường / Vận tốc
        float distance = Vector3.Distance(transform.position, endPos);
        float duration = (distance / speed)+2f;

        // Nếu bạn muốn bay nhanh cố định (ví dụ 1 giây là tới) thì set duration = 1f;

        // 2. Thực hiện bay bằng DOTween
        transform.DOMove(endPos, duration)
            .SetEase(Ease.OutQuad).SetLink(gameObject) // Hiệu ứng: Bay nhanh lúc đầu, chậm dần khi tới nơi (trông tự nhiên hơn Linear)
            .OnComplete(() =>
            {
                // 3. Đoạn code này sẽ chạy SAU KHI bay xong
                isFly = false;
                startshoot = true;

                // Nếu muốn code gọn hơn nữa, bạn có thể gọi hàm bắn tại đây
                // StartShooting(); 
            });
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
