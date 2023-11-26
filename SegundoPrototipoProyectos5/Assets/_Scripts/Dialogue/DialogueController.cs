using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    /*[SerializeField] private TMP_Text dialogueText;
    [SerializeField] private float typingTime; //con 0.05s son 20 char/s

    public static DialogueController instance;
    public GameObject dialogueGameObject;
    public bool didDialogueStart;

    private PlayerMovement playerMovement;
    private AudioSource audioSource;
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        audioSource = player.GetComponent<AudioSource>();
    }

    public void StartDialogue(string[] textLines, bool _isInteractive, GameObject trigger)
    {
        isInteractive = _isInteractive;
        activeTrigger = trigger;
        
        UIManager.CursorVisible();
        UIManager.DesactivateObject(UIController.instance.list);
        UIManager.DesactivateObject(UIController.instance.iconList);
        //AudioManager.instance.ReproduceSound(AudioClipsNames.Pop, audioSource);
        UIManager.ActivateObject(dialogueGameObject);

        playerMovement.canMove = false;

        didDialogueStart = true;
        dialogueLines = textLines;
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    public void EndDialogue()
    {
        didDialogueStart = false;
        playerMovement.canMove = true;

        UIController.instance.CursorInvisible();        
        UIController.instance.ActivateObject(UIController.instance.iconList);                        
        UIController.instance.DesactivateObject(dialogueGameObject);

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
    }*/
}
