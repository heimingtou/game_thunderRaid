using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leaderBoard : MonoBehaviour
{
    public Transform content;       // Content của ScrollView
    public GameObject itemPrefab;   // Prefab Item có LeaderboardItem script

    void Start()
    {
        ShowLeaderboard();
    }

    void ShowLeaderboard()
    {
        List<structData> dataList = saveManger.instance.userSavePointDatas.points;

        var sortedList = dataList.OrderByDescending(x => x.score).ToList();

        foreach (Transform child in content)
            Destroy(child.gameObject);

        for (int i = 0; i < sortedList.Count; i++)
        {
            structData data = sortedList[i];
            GameObject go = Instantiate(itemPrefab, content);

            // Lấy script trên prefab
            leaderboardItem1 item = go.GetComponent<leaderboardItem1>();
            item.SetData(i + 1, data.useName, data.score, data.namePlane,data.coin);
        }
    }
    public void backHome()
    {
        SceneManager.LoadScene("menuScenes");
    }
}
