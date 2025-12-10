using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class playGameManager : MonoBehaviour
{
    public static playGameManager instance;
    public GameObject losePopup;
    // Start is called before the first frame update
    public GameObject pause;
    public GameObject Shield;
    GameObject virtur;
    public GameObject button_shield;
    public TMP_Text result;
    public int coolDown = 30;
    public int active = 5;
    private void Awake()
    {
        instance = this; // gan object gameManger vao instance
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showPopupLose()
    {
        AudioManager.instance.playSFX(AudioManager.instance.EndGame,0.5f);
        losePopup.SetActive(true);
        result.text = saveManger.instance.Score.ToString();
    }
    public void showRank()
    {
       
        AudioManager.instance.playSFX(AudioManager.instance.Click,0.5f);
        SceneManager.LoadScene("scoreScenes");
    }
    public void Pause()
    {
        AudioManager.instance.playSFX(AudioManager.instance.Click,0.5f);
        Time.timeScale = 0;
        pause.SetActive(true);
       
    }
    public void Continue()
    {
        AudioManager.instance.playSFX(AudioManager.instance.Click, 0.5f);
        Time.timeScale = 1;
       
        pause.transform.DOScale(0f, 0.5f).SetEase(Ease.InBack).SetUpdate(true).OnComplete(() => {
            pause.SetActive(false);
        });
    }
    public void replay()
    {
        AudioManager.instance.playSFX(AudioManager.instance.Click, 0.5f);
        SceneManager.LoadScene("gameScenes");
        Time.timeScale = 1;
    }
    public void Exit()
    {
        AudioManager.instance.playSFX(AudioManager.instance.Click, 0.5f);
        SceneManager.LoadScene("menuScenes");
    }
    public void showShield()
    {
        StartCoroutine(ActivateShield());
        Debug.Log("bat dau");
    }
    IEnumerator ActivateShield()
    {
        Debug.Log("bat khien");
        button_shield.SetActive(false);
        Shield.SetActive(true);
        yield return new WaitForSeconds(active);
        Shield.SetActive(false);
        yield return new WaitForSeconds(coolDown);
        Debug.Log("co the bat khien");
        button_shield.SetActive(true);
    }
}
