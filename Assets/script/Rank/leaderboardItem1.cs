using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class leaderboardItem1 : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text rankText;
    public TMP_Text nameText;
    public TMP_Text scoreText;
    public TMP_Text coinText;
    public TMP_Text planeText;

    // Hàm gán dữ liệu
    public void SetData(int rank, string username, int score, string plane,int coin)
    {
        rankText.text = rank.ToString();
        nameText.text = username;
        scoreText.text = score.ToString();
        planeText.text = plane;
        coinText.text = coin.ToString();
    }
}
