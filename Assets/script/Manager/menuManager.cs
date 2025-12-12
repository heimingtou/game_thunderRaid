using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Popup;
    public TMP_InputField usernameInput; // kéo TMP Input Field vào đây
    public Button button;
    void Start()
    {
        button.onClick.AddListener(onPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playGame()
    {
        if (PlayerPrefs.HasKey(userData.Poin_Key))
        {
            startGame();
        }
        else
        {
            showPopup();
        }    
    }
    public void onPlay()
    {
        //Debug.Log("day la ham onplay ");
        string userName = usernameInput.text; // lấy text từ Input Field
        if (string.IsNullOrEmpty(userName))
        {
            Debug.Log("Vui lòng nhập Username!");
            return;
        }
       // Debug.Log(userName);
        // Lưu tạm vào PlayerPrefs để dùng trong scene khác
        PlayerPrefs.SetString("Username", userName);
    }
    public void startGame()
    {
        SceneManager.LoadScene("choseCharacter");

    }
    public void showPopup()
    {
        Popup.SetActive(true);
    }
    public void showRank()
    {
        SceneManager.LoadScene("scoreScenes");
    }

}
