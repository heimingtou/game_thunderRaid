using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; // Chỉ dùng thư viện này để Lưu file trong Editor
#endif

public class LevelDesigner : MonoBehaviour
{
    [Header("Cấu hình lưu dữ liệu")]
    public LevelSpawnData dataToSave; // Kéo file ScriptableObject LevelSpawnData vào đây
    public Transform positionContainer; // Kéo cái GameObj cha chứa các vị trí vào đây
    public int levelIDToSave = 1;     // Nhập ID level bạn muốn lưu (Ví dụ: 1, 2, 3...)

#if UNITY_EDITOR
    // Dòng này tạo menu context khi click chuột phải vào script
    [ContextMenu("--> LƯU VỊ TRÍ VÀO DATA <--")]
    public void SavePositionToData()
    {
        // 1. Kiểm tra đầu vào cho chắc ăn
        if (dataToSave == null)
        {
           // Debug.LogError("LỖI: Bạn chưa kéo file Data vào ô 'Data To Save'!");
            return;
        }
        if (positionContainer == null)
        {
            //Debug.LogError("LỖI: Bạn chưa kéo GameObject chứa vị trí vào ô 'Position Container'!");
            return;
        }

        // 2. Lấy danh sách vị trí từ các con của Container
        List<Vector3> newPositions = new List<Vector3>();
        foreach (Transform child in positionContainer)
        {
            newPositions.Add(child.position);
        }

        // 3. Khởi tạo list trong data nếu nó đang bị null (file mới tạo)
        if (dataToSave.spawnDataItems == null)
        {
            dataToSave.spawnDataItems = new List<LevelSpawnData.spawnDataItem>();
        }

        // 4. Tìm xem ID này đã tồn tại chưa
        bool found = false;
        foreach (var item in dataToSave.spawnDataItems)
        {
            if (item.id == levelIDToSave)
            {
                // Nếu tìm thấy ID trùng, cập nhật lại list vị trí mới
                item.listPosition = newPositions;
                found = true;
                Debug.Log($"<color=green>ĐÃ CẬP NHẬT</color>: Level {levelIDToSave} có {newPositions.Count} vị trí spawn.");
                break;
            }
        }

        // 5. Nếu chưa có ID này thì tạo mới
        if (!found)
        {
            LevelSpawnData.spawnDataItem newItem = new LevelSpawnData.spawnDataItem();
            newItem.id = levelIDToSave;
            newItem.listPosition = newPositions;

            dataToSave.spawnDataItems.Add(newItem);
           // Debug.Log($"<color=cyan>ĐÃ TẠO MỚI</color>: Level {levelIDToSave} với {newPositions.Count} vị trí spawn.");
        }

        // 6. Báo cho Unity biết là file Data đã thay đổi để nó lưu xuống ổ cứng
        EditorUtility.SetDirty(dataToSave);
        AssetDatabase.SaveAssets(); // Lưu ngay lập tức
    }
#endif
}