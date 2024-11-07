using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioClipSO", menuName = "Scriptable Objects/Audio/AudioClipSO", order = 1)]
public class AudioClipSO : ScriptableObject
{
    [SerializeField] private AudioClip audioClip;
    private float volume = 1f;
    private float pitch = 1f;
    [SerializeField] private AudioMixerGroup audioMixerGroup;

    public void PlayOneShoot()
    {
        GameObject audioObject = new GameObject();
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.outputAudioMixerGroup = audioMixerGroup;

        audioSource.Play();
        Destroy(audioObject, audioClip.length);

    }

}