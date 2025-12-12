using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.PlayerSettings;
public class gameManager : MonoBehaviour
{
    public static gameManager instance; // gameManager la toan cuc co the goi o bat ky dau bat ki script nao
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject bossPrefab;
    public GameObject gif;
    public GameObject gif2;
    public GameObject gif3;
    public LevelSpawnData postionSpawn;
    public int spawnId=0;
    public bool isSpawBoss = false;
    //public int score=0;
    //public int Coin = 0;
    readonly Vector3 spawnPos = new Vector3(3f, 4f, 0f); // gia tri khong doi (readonly)
    float shootinterval = 3;
    float lastX;// luu gia tri x cho spawPos 
    //float distance;
    bool allDead=false;
    bool isSpaw = true;// co danh dau da tao
    int countEnemy = 0;
    float level = 0;
    GameObject Enemy;
    List<Vector3> listEndPos;
    //float[] EndPos = { -2f, -0.8f, 0.4f, 1.3f, 2.2f };
    private List<GameObject> enemies = new List<GameObject>();
    Vector3 Pos;
    //int count = 0;
    // Start is called before the first frame update
    
    private void Awake()
    {
        instance = this; // gan object gameManger vao instance
    }
    void Start()
    {
        listEndPos= new List<Vector3>();
        //distance =0.5f;
        //SpEnemy();// ham tao ra enemy
        Pos = spawnPos;
        spawnId = UnityEngine.Random.Range(0, 100) % 7;
        listEndPos = postionSpawn.GetListPosition(spawnId);

    }

    // Update is called once per frame
    void Update()
    {
         checkSpawEnemy();
        ////  kiem tra con song hay khong
        checkDie();
        // sinh enemy khi da chet het
        if (allDead && !isSpaw)
        {
            level++;
            if(level%5==0)
            {
                spawBoss();
            }
            else
                ResetEnemy();
        }
    }
    // sinh enemy khi da chet het
    public void ResetEnemy()
    {
        isSpaw = true;
        shootinterval--;
        countEnemy = 0;
        Pos.x = spawnPos.x + 3;
        Pos.y = spawnPos.y;
        spawnId = UnityEngine.Random.Range(0, 100) % 7;
        listEndPos= postionSpawn.GetListPosition(spawnId);
    }
    // kiem tra co sinh tiep khong
    public void checkSpawEnemy()
    {
        if (countEnemy == (listEndPos.Count-1))
        {
            isSpaw = false;
        }

        if (isSpaw)
        {
           // Debug.Log("spawn Enemy");
            spawEnemyrandom(listEndPos[countEnemy]);
            countEnemy++;
        }
        if (countEnemy % 5 == 0)
        {
            Pos.y -= 0.8f;
            Pos.x = spawnPos.x;
        }
    }

    // kiem tra con song hay khong
    public void checkDie()
    {
        allDead = true;
        foreach (var e in enemies)
        {
            if (e != null)
            {
                allDead = false;
                break;
            }
        }
    }
    // sinh gif
    public  void spawGif(Vector3 spawGifs)
    {
        float check = UnityEngine.Random.Range(0, 6) % 5;
        //Debug.Log(check);
        if (check == 1)
        {
            Instantiate(gif2, spawGifs, Quaternion.identity);
        }
        else if (check == 2)
        {
            Instantiate(gif, spawGifs, Quaternion.identity);
        }
        else
        {
            //Debug.Log("roi tien");
            Instantiate(gif3, spawGifs, Quaternion.identity);
        }
    }
    //public void addScore()
    //{
    //    score++;
    //    PlayerPrefs.SetInt(userData.Poin_Key,score);
    //}
    void spawEnemy(GameObject enemyprefab, Vector3 SpawnPos, Vector3 EndPos)
    {
        // lay huong bay
        bool directionFly = false;
        // gan huong bay 
        //Debug.Log("da chay spawEnemy");
        if ((UnityEngine.Random.Range(0, 30) % 2) == 1)
        {
            SpawnPos.x = -1 * SpawnPos.x;
            directionFly = !directionFly;
        }
        Enemy = Instantiate(enemyprefab, SpawnPos, Quaternion.identity);
            Enemy enemyScript = Enemy.GetComponent<Enemy>();   // lay script Enemy cua enemy moi tao
            enemyScript.flyRight = directionFly;
        enemyScript.FlyToPosition(EndPos);
            enemies.Add(Enemy);
    }
    // ham sinh ra enemy
    void spawEnemyrandom(Vector3 EndPos)
    {
       // Debug.Log("da chay spawEnemyRandom");
        float check = UnityEngine.Random.Range(0, 50) % 4;
        if (check == 1)
            spawEnemy(enemyPrefab3, Pos,EndPos);
        else if (check == 0)
            spawEnemy(enemyPrefab2, Pos, EndPos );
        else
            spawEnemy(enemyPrefab, Pos, EndPos);
    }
    void spawBoss()
    {
        Vector3 PosBoss = new Vector3(0, 5, 0);
        Vector3 EndPos = new Vector3(0, 3, 0);
        spawEnemy(bossPrefab, PosBoss, EndPos);
        isSpawBoss = false;
    }
    public void endGame()
    {
        Time.timeScale = 0f;
    }
   
   
}
