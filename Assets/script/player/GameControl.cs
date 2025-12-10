using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

// dung ham A.atan2 de xoay theo huong di chuyen
// tu implement bang vat ly giup de dieu chinh

public class GameControl : MonoBehaviour
{ 
    //Vector3 spawnPosStart = new Vector3(-3.5f, 3.5f, 0f);
    bool canShoot = false;// chua cho phep ban
    float timer = 0;
    public GameObject gun;
    public GameObject bulletprefab;
    public GameObject bulletlazer;
    GameObject lazer;
    //bool isLazer=false;
    public float Speed = 5f;
    public int x=1;
    public int y=0;
    public float angel;
    public float checkKey = 0;
    public float giatoc = 0.05f;
    public GameObject goPos;

    // Start is called before the first frame update
   
    void Start()
    {
        transform.DOMove(goPos.transform.position, 2f).SetEase(Ease.OutBack);
        Debug.Log("tien len");
        Invoke("EnableShooting", 2f);// goi EnableShooting sau 1 giay ke tu khi bat dau
        Application.targetFrameRate = 60; // dat FPS
        //bulletlazer.transform.localScale = new Vector3(0, 0, 1);
    }
    void EnableShooting()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (!canShoot)
            { return; }
        float y = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");
        angel = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        Move(viewPos);
        if (! bulletManger.instance.isLazer)
        { shoot();
           // Debug.Log(isLazer);
        }
        else if (lazer==null)
           { shootlazer();
            //Debug.Log(isLazer);
            Invoke("stopLazer", 10f);
        }
    }
    void stopLazer()
    {
        bulletManger.instance.isLazer = false;
        Debug.Log("huy lazer");
        Destroy(lazer);
        //bulletlazer.SetActive(false);
    }
    
    private void shootlazer()
    {
        Debug.Log("banLazer");
        //bulletlazer.SetActive(true);
        Vector3 gunPos = new Vector3(gun.transform.position.x, gun.transform.position.y, gun.transform.position.z);
        lazer = Instantiate(bulletlazer, gunPos, gun.transform.rotation);
        lazer.transform.SetParent(gun.transform);
        // isshoot = false;
        //isLazer = false;
    }
    private void shoot()
    {
        float Angel = Mathf.Atan2(bulletManger.instance.countGun/2, 11f) * Mathf.Rad2Deg;// goc ban
        timer += Time.deltaTime;
        //AudioManager.instance.playSFX(AudioManager.instance.shoot,0.2f);
        if (timer >= 0.1f)
        ////////////vat the goc/////noi sinh ra dan///////huong quay
        {
            Quaternion directionOfShoot = gun.transform.rotation;
            Vector3 posShoot = gun.transform.position;
            if(bulletManger.instance.countGun > 3)
            {
                directionOfShoot= Quaternion.Euler(0f, 0f, directionOfShoot.eulerAngles.z - Angel);
                Angel *= 2;
                for (int i = 0; i < bulletManger.instance.countGun; i++)
                {
                    Instantiate(bulletprefab, posShoot, directionOfShoot);
                    directionOfShoot = Quaternion.Euler(0f, 0f, directionOfShoot.eulerAngles.z + (Angel/(bulletManger.instance.countGun)));
                }
            }
            else
           {
                int n = bulletManger.instance.countGun;
                if (bulletManger.instance.countGun % 2!=0)
                {
                    Instantiate(bulletprefab, posShoot, directionOfShoot);
                    n--;
                }
                for (int i = 0; i < n; i++)
                {
                    if (bulletManger.instance.countGun > 1)
                    {
                        if (i % 2 == 0)
                            posShoot.x = gun.transform.position.x + ((i + 1f) / 8f);

                        else
                            posShoot.x = gun.transform.position.x - ((i) / 8f);
                    }
                    Instantiate(bulletprefab, posShoot, directionOfShoot);
                }
            }
            timer = 0;
        }
    }

    // gun.transform.rotation đạn quay theo hướng cuar máy bay
    //directionOfShoot= Quaternion.Euler(0f,0f, directionOfShoot.eulerAngles.z+5);
    void a(float giatoc)
    {
        if (giatoc < 0)
        {
            if (Speed > 0)
                Speed += giatoc;
        }

        if (Speed < 5)
            Speed += giatoc;
    }
    
    private void Move(Vector3 viewPos)
    {
        angel = Mathf.Atan2(0.5f, 8f) * Mathf.Rad2Deg;
        if (Input.GetKey(KeyCode.RightArrow)&& (viewPos.x<1))
        { // bat phim
            a(0.5f);
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0,-1* angel);
            checkKey = 1;
          
            //x = 1; y = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && (viewPos.x>0))
        { // bat phim
            a(0.5f);
            transform.position += new Vector3(-1 * Speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, angel);
            checkKey = 2;
          
        }
        else if (Input.GetKey(KeyCode.DownArrow) && (viewPos.y > 0))
        { // bat phim
            a(0.5f);
            transform.position += new Vector3(0, -1 * Speed * Time.deltaTime, 0);
            //transform.rotation = Quaternion.Euler(0, 0, angel);
            checkKey = 3;
           
        }
        else if (Input.GetKey(KeyCode.UpArrow) && (viewPos.y < 1))
        { // bat phim
            a(0.5f);
            transform.position += new Vector3(0, Speed * Time.deltaTime, 0);
            //transform.rotation = Quaternion.Euler(0, 0, angel);
            checkKey = 4;
            
        }
        else  
        {
            
            
            if (Speed > 0)
            {
               
                transform.rotation = Quaternion.Euler(0, 0, 0);
                if (checkKey==4 && ( viewPos.y<1))
                transform.position += new Vector3(0, Speed * Time.deltaTime, 0);
                else if(checkKey==3 && ( viewPos.y>0))
                    transform.position += new Vector3(0, -1 * Speed * Time.deltaTime, 0);
                else if(checkKey== 2 && (  viewPos.x>0))
                    transform.position += new Vector3(-1 * Speed * Time.deltaTime, 0, 0);
                else if(checkKey ==1&& (viewPos.x<1))
                    transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
                a(-0.3f);
            }
                
        } 
    }
}
