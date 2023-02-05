using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private bool dialogueOn;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one Dialogue Manager present in the scene!");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueOn = false;
        dialoguePanel.SetActive(false);
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        dialogueOn = true;
        dialoguePanel.SetActive(true);

        ContinueDialogue();
    }

    private void ExitDialogueMode()
    {
        dialogueOn = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueDialogue()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueOn)
        {
            return;
        }

        if (Input.GetKeyDown("space"))
        {
            ContinueDialogue();
        }
    }


}
