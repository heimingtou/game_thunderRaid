using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class loadPlayer : MonoBehaviour
{
    public characterData characterDb;
    GameObject player;
    GameObject Shield;
     
    public GameObject Pos;
    public int indexCharacterSelected;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(userData.IndexCharacter_Key))
        {
            load();
        }
        else
        {
            indexCharacterSelected = 0;
        }
        updateCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateCharacter()
    {
        character character = characterDb.GetCharacter(indexCharacterSelected);
        player = character.playerObject;
        player=Instantiate(player,Pos.transform.position,Quaternion.identity);
        
        Shield= playGameManager.instance.Shield;
        Shield.transform.SetParent(player.transform);
        Shield.transform.localPosition = Vector3.zero;
        Shield.SetActive(false);
       
        Debug.Log("spaw player");
    }
    

    public void load()
    {
        indexCharacterSelected = PlayerPrefs.GetInt(userData.IndexCharacter_Key);
    }
}
