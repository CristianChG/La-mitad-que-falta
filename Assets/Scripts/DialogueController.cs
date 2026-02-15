using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public DialogueLine[] lines;
    public GameObject dialoguePanel;
    public TMP_Text speakerText;
    public TMP_Text bodyText;
    public KeyCode advanceKey = KeyCode.Space;

    private int currentIndex;
    private bool isActive;

    void Start()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (Input.GetKeyDown(advanceKey))
        {
            Debug.Log("Advance dialogue");
            Advance();
        }
    }

    public void StartDialogue()
    {
        if (lines == null || lines.Length == 0)
        {
            return;
        }

        currentIndex = 0;
        isActive = true;

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(true);
        }

        ShowCurrentLine();
    }

    public void EndDialogue()
    {
        isActive = false;

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    private void Advance()
    {
        currentIndex++;

        if (currentIndex >= lines.Length)
        {
            EndDialogue();
            return;
        }

        ShowCurrentLine();
    }

    private void ShowCurrentLine()
    {
        DialogueLine line = lines[currentIndex];

        if (speakerText != null)
        {
            speakerText.text = line.speaker;
        }

        if (bodyText != null)
        {
            bodyText.text = line.line;
        }
    }
}
