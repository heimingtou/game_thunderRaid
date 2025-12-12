using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManger : MonoBehaviour
{
    public int countGun = 1;
    public static bulletManger instance; // gameManager la toan cuc co the goi o bat ky dau bat ki script nao
    public bool isLazer=false;

    private void Awake()
    {
        instance = this; // gan object gameManger vao instance
    }
    // Start is called before the first frame update
   
    public void AddBullet()
    {
        countGun++;
    }
}
