using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewLevelData", menuName = "GameData/Level Spawn Data")]
public class LevelSpawnData : ScriptableObject
{
    [System.Serializable]
    public class spawnDataItem
    {
        public int id;
        public List<Vector3> listPosition;
    }
    public List<spawnDataItem> spawnDataItems;
    // Start is called before the first frame update
    public Dictionary<int, List<Vector3>> spawnPosition;
    public void OnEnable()
    {
        spawnPosition = new Dictionary<int, List<Vector3>>();
        if (spawnDataItems == null) return;
        foreach (var item in spawnDataItems)
        {
            if (!spawnPosition.ContainsKey(item.id))
            {
                spawnPosition.Add(item.id, item.listPosition);
            }
        }
        
    }
    public List<Vector3> GetListPosition(int id)
    {
        List<Vector3> ListPositionSpawn=new List<Vector3>();
        ListPositionSpawn = spawnPosition[id];
        return ListPositionSpawn;

    }
}
