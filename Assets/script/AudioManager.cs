using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour


{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    

    [Header("--------- Audio SFX ---------")]
    public AudioClip click1;
    public AudioClip click2;
    public AudioClip click3;
    public AudioClip click4;
    public AudioClip OpenMenu;
    public AudioClip CloseMenu;

    [Header("--------- Audio Music ---------")]
    public AudioClip Music1;
    [Header("--------- Audio Ambiance ---------")]
    public AudioClip ambiance1;

    private void Start()
    {
        musicSource.clip = Music1;
        musicSource.Play();
        SFXSource.clip = ambiance1;
        SFXSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }


}
