using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject dialogueBox;

    public bool isOpen { get; private set; }

    private TypewriterEffect typewriterEffect;
    private ResponseHandler responseHandler;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        closeDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
        
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

        for (int i=0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasRespone)
            {
                break;
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObject.HasRespone)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            closeDialogueBox();
        }
    }

    private void closeDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
