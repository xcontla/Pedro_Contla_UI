using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;



public class OptionMenu : MonoBehaviour
{

    public AudioMixer audiomixer;

    private float currentMusicVolume;
    private float currentAmbientalVolume;
    private float currentSfxVolume;

    public void Start()
    {
        SetVolume(0.5f);
    }

    public void QuitGame()
    {

        Debug.Log("Quitting APP");
        SoundFxManager.Instance.playSound();
        Application.Quit(); 
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);

        float vlrange = 5.0f * volume + (-30.0f) * (1.0f - volume);  
        
        audiomixer.SetFloat("volumen", vlrange);


    }

    public void SetAmbientalVolume(float volume)
    {
        Debug.Log(volume);

        float vlrange = 5.0f * volume + (-30.0f) * (1.0f - volume);

        audiomixer.SetFloat("volumenAmbiental", vlrange);


    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log(volume);

        float vlrange = 5.0f * volume + (-30.0f) * (1.0f - volume);

        audiomixer.SetFloat("volumenMusic", vlrange);


    }

    public void SetSfxVolume(float volume)
    {
        Debug.Log(volume);

        float vlrange = 5.0f * volume + (-30.0f) * (1.0f - volume);

        audiomixer.SetFloat("volumenSFx", vlrange);


    }
}
