using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXsource;

    public AudioClip PlayGame;
    public AudioClip EndGame;
    public AudioClip Click;
    public AudioClip shoot;
    public AudioClip putGif;
    public AudioClip explore;
    public static AudioManager instance; // gameManager la toan cuc co the goi o bat ky dau bat ki script nao
    
    private void Awake()
    {
        instance = this; // gan object gameManger vao instance
    }
    private void Start()
    {
        musicSource.clip = PlayGame;
        musicSource.loop= true;
        musicSource.Play();
        
    }
    public void playSFX(AudioClip music, float volumn)
    {
        SFXsource.PlayOneShot(music,volumn);
    }
}
