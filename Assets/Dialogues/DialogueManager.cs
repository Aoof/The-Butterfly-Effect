using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;

    public GameObject player;

    public bool dialogueOn { get; private set; }

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
        currentStory = new Story(inkJSON.text);
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
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueOn)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ContinueDialogue();
        }
    }


}
