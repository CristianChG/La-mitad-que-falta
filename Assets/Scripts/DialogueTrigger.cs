using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMarker;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines; 

    private bool isPlayerInRange;
    private bool didStartDialogue;
    private int lineIndex;
    private float typewriterSpeed = 0.02f;
    

    void Update()
    {
        var keyboard = Keyboard.current;
        if (isPlayerInRange && keyboard != null && keyboard.eKey.wasPressedThisFrame)
        {
            if (!didStartDialogue)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                AdvancedeDialogue();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didStartDialogue = true;
        dialogueMarker.SetActive(false);
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowDialogue());
    }

    private void AdvancedeDialogue()
    {
        if (lineIndex < dialogueLines.Length - 1)
        {
            lineIndex++;
            StartCoroutine(ShowDialogue());
        }
        else
        {
            didStartDialogue = false;
            dialoguePanel.SetActive(false);
            dialogueMarker.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowDialogue()
    {
        dialogueText.text = string.Empty;
        foreach (char letter in dialogueLines[lineIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typewriterSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMarker.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))        
        {
            isPlayerInRange = false;
            dialogueMarker.SetActive(false);
        }
    }
}
