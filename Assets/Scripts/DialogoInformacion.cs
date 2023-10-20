using System.Collections;
using UnityEngine;
using TMPro;

public class DialogoInformacion : MonoBehaviour
{
    [SerializeField, TextArea(4,6)]
    public string[] lineasDialogo;

    [SerializeField] private GameObject dialogoPanel;
    [SerializeField] private TMP_Text dialogoText;

    private bool isPlayerInRange;
    private int rotationAngle;

    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime;

    private void Start()
    {
        rotationAngle = 0;
        isPlayerInRange = false;
        didDialogueStart = false;
        typingTime = 0.05f;
    }

    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Fire2"))
        {

            if(!didDialogueStart)
            {
                rotationAngle = 0;
                StartDialogue();
            }
            else if(dialogoText.text == lineasDialogo[lineIndex])
            {
                rotationAngle = 0;
                NextDialogueLine();
            }
            else
            {
                rotationAngle = 0;
                StopAllCoroutines();
                dialogoText.text = lineasDialogo[lineIndex];
            }
        }
        else
        {

            this.transform.Rotate(new Vector3(0.0f, rotationAngle, 0.0f));
        }
    }

    private void StartDialogue()
    {
        Time.timeScale = 0f;
        didDialogueStart = true;
        dialogoPanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < lineasDialogo.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            rotationAngle++;
            didDialogueStart = false;
            dialogoPanel.SetActive(false);
            Time.timeScale = 1f;

        }
    }

    private IEnumerator ShowLine()
    {
        dialogoText.text = string.Empty;
        foreach(char ch in lineasDialogo[lineIndex])
        {
            dialogoText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }


    }    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            rotationAngle++;
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            rotationAngle = 0;
        }
    }
}
