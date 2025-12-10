using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserSaveDatas
{
    //lưu ds điểm qua các lần chơi
    public List<structData> points;

    public UserSaveDatas()
    {
        points = new List<structData>();
    }
    //đầu game
    public void StartGame(string userName,string namePlane)
    {
        structData data= new structData();
        data.useName = userName;
        data.namePlane = namePlane;
        data.score = 0;
        data.coin = 0;
        points.Add(data);
    }
    //sửa điểm hiện tại
    public void UpdatePoints(int point)
    {
        //points.Last()
        if (points.Count > 0)
        {
            structData temp = points[points.Count - 1];
            temp.score = point;
            points[points.Count - 1] = temp;
        }
    }
    public void UpdateCoin(int coin)
    {
        //points.Last()
        if (points.Count > 0)
        {
            structData temp = points[points.Count - 1];
            temp.coin = coin;
            points[points.Count - 1] = temp;
        }
    }
}