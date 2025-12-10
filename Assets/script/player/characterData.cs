using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class characterData : ScriptableObject //Tách data khỏi code/Giảm duplicate dữ liệu/Dễ chỉnh sửa/Tối ưu bộ nho/Chia sẻ dữ liệu giữa nhiều object
{
    // Start is called before the first frame update
   public  List<character> listCharacter;
    
    public  characterData()
    {
        listCharacter = new List<character>();
    }
    public int countCharacter()
    {
            return listCharacter.Count;
    }

    public character GetCharacter(int index)
    {
       
        return listCharacter[index];
    }

}
