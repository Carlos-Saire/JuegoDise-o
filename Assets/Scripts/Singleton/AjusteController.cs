using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
public class AjusteController : MonoBehaviour
{
    static public AjusteController instance;

    [SerializeField] private Animator animator;

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private string master;
    [SerializeField] private string music;
    [SerializeField] private string sfx;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
    }
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(master, Mathf.Log10(volume) * 20);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(music, Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(sfx, Mathf.Log10(volume) * 20);
    }
    public void OpenAjustes()
    {
        animator.ResetTrigger("Close");
        animator.SetTrigger("Open");
    }

    public void CloseAjustes()
    {
        animator.ResetTrigger("Open");
        animator.SetTrigger("Close");
    }
}
