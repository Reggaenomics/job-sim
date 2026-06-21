using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Tooltip("Drag in your full-screen panel here (DialoguePanel)")]
    public GameObject dialoguePanel;

    [Tooltip("Your PlayerController component")]
    public PlayerController playerController;

    [Tooltip("Your MouseLook component")]
    public MouseLook mouseLook;

    [Tooltip("The TMP text that shows the dialogue body")]
    public TextMeshProUGUI dialogueBodyText;

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
        RefreshDialogueText();
        playerController.enabled = false;
        mouseLook.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void RefreshDialogueText()
    {
        if (dialogueBodyText == null) return;

        var cm = CurrencyManager.Instance;
        string status = cm.IsEmployed ? $"EMPLOYED - {cm.JobTitle}" : "UNEMPLOYED";
        dialogueBodyText.text =
            $"Welcome to McDick's\n\n\n    You are currently {status}\n\n\n    Would you like to work a shift?";
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
        playerController.enabled = true;
        mouseLook.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void DoJob()
    {
        CurrencyManager.Instance.AddMoney(10);
    }
}
