using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gif_1 : gif
{
    // Start is called before the first frame update
     public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        GameControl gameCtrl = other.gameObject.GetComponent<GameControl>();

        if (gameCtrl != null)
        {
            if (bulletManger.instance.countGun < 11)
                bulletManger.instance.AddBullet();
        }
    }
}
