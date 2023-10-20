using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxManager : MonoBehaviour
{

    public AudioSource sfxAudioSource;
    public AudioClip[] sfxClips;

    public static SoundFxManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void playSound() 
    {
        sfxAudioSource.PlayOneShot(sfxClips[0]);

    }
}
