using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogImage : MonoBehaviour
{
    [SerializeField] public GameObject gameHud;
    public void ShowDetails()
    {
        Debug.Log("Details");
        gameHud.SetActive(true);
    }

    public void UnShowDetails()
    {
        Debug.Log("NoDetails");
        gameHud.SetActive(false);
    }
}
