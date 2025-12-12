using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class saveManger : MonoBehaviour
{
    public static saveManger instance; // gameManager la toan cuc co the goi o bat ky dau bat ki script nao
    public int Score;
    public int Coin;
    public string userName;
    // Start is called before the first frame update
    //data schema -> user save point datas
    public UserSaveDatas userSavePointDatas;
    private void Awake()
    {
        instance = this; // gan object gameManger vao instance
    }
    void Start()
    {
        if (PlayerPrefs.HasKey(userData.Poin_Key))
        {
            string jsonData = PlayerPrefs.GetString(userData.Poin_Key);
            //Debug.Log("jsonData: " + jsonData);
            //FromJson: chuyển từ string sang object
            //ToJson: chuyển từ object sang string
            userSavePointDatas = JsonUtility.FromJson<UserSaveDatas>(jsonData);
            //Debug.Log("userSavePointDatas: " + UserSaveDatas.points.Count);
        }
        else
        {
            userSavePointDatas = new UserSaveDatas();
            //Debug.Log("new user");
        }
        userName = PlayerPrefs.GetString("Username");
        string planeName = PlayerPrefs.GetString(userData.planeName_key);
        //Debug.Log("useName: " + userName);
        //đầu game
        userSavePointDatas.StartGame(userName,planeName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addPoint()
    {
        Score++;
        userSavePointDatas.UpdatePoints(Score);
        string jsonData = JsonUtility.ToJson(userSavePointDatas);
        PlayerPrefs.SetString(userData.Poin_Key, jsonData);
        PlayerPrefs.Save();
    }
    public void addCoin()
    {
        Coin++;
        userSavePointDatas.UpdateCoin(Coin);
        PlayerPrefs.SetInt(userData.Coin_Key, Coin);
        string jsonData = JsonUtility.ToJson(userSavePointDatas);
        PlayerPrefs.SetString(userData.Poin_Key, jsonData);
        PlayerPrefs.Save();
    }
}
