using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewLevelData", menuName = "GameData/Level Spawn Data")]
public class LevelSpawnData : ScriptableObject
{
    // Start is called before the first frame update
    public List<Vector3> spawnPosition;
}
