using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Tooltip("Drag in your full-screen panel here (DialoguePanel)")]
    public GameObject dialoguePanel;

    [Tooltip("Your PlayerController component")]
    public PlayerController playerController;

    [Tooltip("Your MouseLook component")]
    public MouseLook mouseLook;

    bool playerNearby = false;

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        // open when “E” and player is in range
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
            OpenDialogue();

        // close on Esc
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            CloseDialogue();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }

    void OpenDialogue()
    {
        dialoguePanel.SetActive(true);
        playerController.enabled = false;
        mouseLook.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
        playerController.enabled = true;
        mouseLook.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
