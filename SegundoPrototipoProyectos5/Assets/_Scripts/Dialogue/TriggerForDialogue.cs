using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class TriggerForDialogue : MonoBehaviour
{
    DialogueController dialogueController;
    [SerializeField] private bool isInteractive;

    [TextArea(2, 4)] public string[] textLines;// 2 = minNumLineas, 6 = maxNumLineas

    private void Start()
    {      
        dialogueController = GameObject.FindGameObjectWithTag("Canvas").GetComponent<DialogueController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!dialogueController.didDialogueStart && !isInteractive)
            {
                dialogueController.StartDialogue(textLines, isInteractive, gameObject);
            }
        }        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButton("Interact") && !dialogueController.didDialogueStart && isInteractive)
        {
            dialogueController.StartDialogue(textLines, isInteractive, gameObject);
        }
    }    
}
