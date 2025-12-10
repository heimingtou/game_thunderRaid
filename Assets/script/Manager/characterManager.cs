using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class characterManager : MonoBehaviour
{
    public characterData characterDb;
    public Image Spritecharacter;
    public TMP_Text nameCharacter;
    public int indexCharacterSelected;
    public character character;
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
    public void next()
    {
        indexCharacterSelected++;
        if(indexCharacterSelected>=characterDb.countCharacter())
        {
            indexCharacterSelected = 0;
        }
        updateCharacter();
    }
    public void back()
    {
        indexCharacterSelected--;
        if (indexCharacterSelected <0)
        {
            indexCharacterSelected = characterDb.countCharacter()-1;
        }
        updateCharacter();
    }
    public void updateCharacter()
    {
       character = characterDb.GetCharacter(indexCharacterSelected);
        
        nameCharacter.text = character.characterName;
        Spritecharacter.sprite = character.playerSprite;
        
       // FitSpriteToSquare(Spritecharacter, 1);
    }
    //public Vector2 targetSize = new Vector2(1f, 1f); // kích thước muốn hiển thị

    //void FitSpriteToSquare(Image img, float targetWorldSize)
    //{
    //    if (img.sprite == null) return;

    //    // kích thước sprite thật theo đơn vị world
    //    Vector2 spriteSize = img.sprite.rect.size / img.sprite.pixelsPerUnit;

    //    float scaleX = targetWorldSize / spriteSize.x;
    //    float scaleY = targetWorldSize / spriteSize.y;

    //    float scale = Mathf.Min(scaleX, scaleY);

    //    img.rectTransform.localScale = new Vector3(scale, scale, 1);
    //}
    public void savePlaneName()
    {
        PlayerPrefs.SetString(userData.planeName_key, character.characterName);
    }
    public void playGame()
    {
        Save();
        savePlaneName();
        Time.timeScale = 1;
        SceneManager.LoadScene("gameScenes");
    }
    public void load()
    {
        indexCharacterSelected= PlayerPrefs.GetInt(userData.IndexCharacter_Key);
    }
    // Update is called once per frame
    public void Save()
    {
        PlayerPrefs.SetInt(userData.IndexCharacter_Key, indexCharacterSelected);
    } 
}
