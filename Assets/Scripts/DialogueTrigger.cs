using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogueTrigger : MonoBehaviour
{
    public DialogueController dialogueController;
    public DialogueLine[] lines;
    public KeyCode interactKey = KeyCode.E;

    private bool playerInRange;

    void Update()
    {
        if (!playerInRange || dialogueController == null)
        {
            return;
        }

        if (Input.GetKeyDown(interactKey))
        {
            dialogueController.lines = lines;
            dialogueController.StartDialogue();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
