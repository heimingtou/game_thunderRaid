using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Boss_1 : Enemy
{
    // Start is called before the first frame update
    public override void FlyToPosition(Vector3 endPos)
    {
        if(transform.position.y>2.8f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else
        {
            startshoot = true;
        }
    }
     public override void shoot()
    {
        timer += Time.deltaTime;
        float r = UnityEngine.Random.Range(-3, 4);
        float Angel = Mathf.Atan2(r, 7f)*Mathf.Rad2Deg;
        if (timer > 0.5f)
        {
            Quaternion direction = Quaternion.Euler(0, 0, 180+Angel);
            Instantiate(bulletPrefab, gun.transform.position, direction);
            //Debug.Log(direction);
            timer = 0;
        }
    }
    public override void die()
    {
        //gameManager.instance.score++;
        //Debug.Log(gameManager.instance.score);
        Vector3 posGif = this.gameObject.transform.position;
       
        for (int i = 0; i < 10; i++)
        { gameManager.instance.spawGif(posGif); }
        Destroy(this.gameObject);
    }
}
