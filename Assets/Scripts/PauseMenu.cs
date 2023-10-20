using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject gameHud;
    public void Pause()
    {
        Time.timeScale = 0.0f;
        gameHud.SetActive(false);
        transform.gameObject.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1.0f;
        transform.gameObject.SetActive(false);
        gameHud.SetActive(true);
    }

    public void Exit()
    {
        
    }
}
