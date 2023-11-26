using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private float typingTime; //con 0.05s son 20 char/s

    public static DialogueController instance;
    public GameObject dialogueGameObject;
    public bool didDialogueStart;

    private AudioSource audioSource;
    private UIManager uiManager;
    private int lineIndex;
    private string[] dialogueLines; 
    private bool isInteractive;
    private GameObject activeTrigger;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    { 
        uiManager = GetComponent<UIManager>();
        audioSource = GetComponent<AudioSource>();
    }

    public void StartDialogue(string[] textLines, bool _isInteractive, GameObject trigger)
    {
        isInteractive = _isInteractive;
        activeTrigger = trigger;
        
        uiManager.IsInGame(false);
        uiManager.DesactivateAllUIGameObjects();
        //AudioManager.instance.ReproduceSound(AudioClipsNames.Pop, audioSource);
        uiManager.ActivateUIGameObjects(uiManager.dialoguePanel, true);

        didDialogueStart = true;
        dialogueLines = textLines;
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    public void EndDialogue()
    {
        didDialogueStart = false;

        uiManager.IsInGame(true);
        uiManager.DesactivateAllUIGameObjects();

        if (!isInteractive)
        {
            Destroy(activeTrigger);
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    public void NextDialogueLine()
    {
        //AudioManager.instance.ReproduceSound(AudioClipsNames.Click, audioSource);

        if (dialogueText.text == dialogueLines[lineIndex]) //si enseña la linea completa
        {
            lineIndex++;
            if (lineIndex < dialogueLines.Length)
            {
                StartCoroutine(ShowLine());
            }
            else
            {
                EndDialogue();
            }
        }
        else if (lineIndex > dialogueLines.Length)
        {
            EndDialogue();
        }
        else
        {
            EndLineFast();
        }
    }

    private void EndLineFast()
    {
        StopAllCoroutines();
        dialogueText.text = dialogueLines[lineIndex];
    }
}
