using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    [System.Serializable]
    public class PoolItem
    {
        public string name;
        public GameObject prefabBullet;
        public int amount;
    }
    public List<PoolItem> pooledObject;
    public Dictionary<string, List<GameObject>> PoolObjectDict;
    public Dictionary<string, GameObject> prefabPoolObject;
    public static poolManager instance;
    private void Awake()
    {
        instance = this; // gan object gameManger vao instance
    }
    void Start()
    {
        PoolObjectDict = new Dictionary<string, List<GameObject>>();
        prefabPoolObject=new Dictionary<string, GameObject>();
        foreach (PoolItem item in pooledObject)
        {
            List<GameObject> list = new List<GameObject>();
            for(int i=0;i<item.amount;i++)
            {
                GameObject obj = Instantiate(item.prefabBullet);
                obj.SetActive(false);
                list.Add(obj);
            }
            PoolObjectDict.Add(item.name, list);
            prefabPoolObject.Add(item.name, item.prefabBullet);
        }
    }
    public GameObject addBullletToPool(string name)
    {
        List<GameObject> addPool = PoolObjectDict[name];
        GameObject obj = Instantiate(prefabPoolObject[name]);
        obj.SetActive(false);
        addPool.Add(obj);
        return obj;
    }
    public GameObject GetBullet(string name)
    {
        // kiem tra co ton tai bullet name truyen vao hay khong 
        if(PoolObjectDict.ContainsKey(name))
        {
            List<GameObject>bulletOfShoot= PoolObjectDict[name];
            for(int i=0;i<bulletOfShoot.Count;i++)
            {
                // tim vien dan chua duoc ban va tra no ve
                if(!bulletOfShoot[i].activeInHierarchy)
                {
                    return bulletOfShoot[i];
                }
            }
           return addBullletToPool(name);
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
