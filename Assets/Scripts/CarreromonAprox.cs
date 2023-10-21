using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarreromonAprox : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)]
    public string[] lineasDialogo;

    [SerializeField] private GameObject dialogoPanel;
    [SerializeField] private TMP_Text dialogoText;

    private bool isPlayerInRange;

    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime;

    public CarreromonData cdata;


    private void Start()
    {
        isPlayerInRange = false;
        didDialogueStart = false;
        typingTime = 0.05f;
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire2"))
        {

            if (!didDialogueStart)
            {
              
                StartDialogue();
            }
            else
            {
             
                StopAllCoroutines();
                dialogoText.text = lineasDialogo[lineIndex];
                didDialogueStart = false;
                dialogoPanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    private void StartDialogue()
    {
        Time.timeScale = 0f;
        didDialogueStart = true;
        dialogoPanel.SetActive(true);

        StartCoroutine(chooseCorutine());
    }


    private IEnumerator ShowLines0()
    {
        lineIndex = 0;
        dialogoText.text = string.Empty;
        foreach (char ch in lineasDialogo[0])
        {
            dialogoText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }

        didDialogueStart = false;


    }

    private IEnumerator ShowLines1()
    {
        lineIndex = 1;
        dialogoText.text = string.Empty;
        foreach (char ch in lineasDialogo[1])
        {
            dialogoText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }

        didDialogueStart = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;

        }
    }


    private string chooseCorutine()
    {

        int count = 0;
        for(int i = 0; i < cdata.dimensionesNombre.Length; i++)
            foreach (InventoryItem ii in InventorySystem.Instance.inventoryAptitudes)
            {
                if (cdata.dimensionesNombre[i] != ii.data.id)
                    continue;
                else
                {
                    count++;
                    if (ii.stackSize < cdata.dimensionesValor[i])
                    {
                        return "ShowLines0";
                    }

                }
        }


        for (int i = 0; i < cdata.dimensionesNombre.Length; i++)
            foreach (InventoryItem ii in InventorySystem.Instance.inventoryIntereses)
            {
                if (cdata.dimensionesNombre[i] != ii.data.id)
                    continue;
                else
                {
                    count++;
                    if (ii.stackSize < cdata.dimensionesValor[i])
                    {
                        return "ShowLines0";
                    }

                }
            }



        if (count == cdata.dimensionesNombre.Length)
            return "ShowLines1";
        return "ShowLines0"; 

    }
}
