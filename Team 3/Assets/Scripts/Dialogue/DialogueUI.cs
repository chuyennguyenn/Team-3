using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;
    [SerializeField] private GameObject dialogueBox;

    private TypewriterEffect typewriterEffect;
    private ResponseHandler responseHandler;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        closeDialogueBox();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
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
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
