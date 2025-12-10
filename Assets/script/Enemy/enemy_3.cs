using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_3 : Enemy
{
    public float time=0;
    Quaternion rotate;
    public int countBullet=0;
    private float Angel= Mathf.Atan2(3f, 5f) * Mathf.Rad2Deg;
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        randomTimeShoot();
        rotate = Quaternion.Euler(0, 0, -Angel-180);
    }
    public override void shoot()
    {
        time += Time.deltaTime;
        timer += Time.deltaTime;
        if(timer>shootTime)
        {    if (time >= 0.01f)
            {
                Instantiate(bulletPrefab, gun.transform.position, rotate);
                rotate = Quaternion.Euler(0, 0, rotate.eulerAngles.z + (Angel / 2.5f));
                time = 0;
                countBullet++;
            }
            if (countBullet == 5)
            {
                //isShoot = false;
                rotate = Quaternion.Euler(0, 0, -Angel - 180);
                timer = 0;
                countBullet = 0;
            }
        }
    }
}
