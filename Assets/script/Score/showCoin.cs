using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class showCoin : MonoBehaviour
{
    public TMP_Text textCoin;
    int lastCoin = 0;
    // Start is called before the first frame update
    void Start()
    {
        textCoin.text=lastCoin.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(lastCoin!=saveManger.instance.Coin)
        {
            textCoin.text = saveManger.instance.Coin.ToString();
            lastCoin= saveManger.instance.Coin;
        }
    }
}
