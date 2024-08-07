using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject DialogueObject;

    public void Interact(Play player)
    {
        player.DialogueUI.ShowDialogue(DialogueObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.TryGetComponent(out Play player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.TryGetComponent(out Play player))
        {
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this) {
                player.Interactable = null;
            }
        }
    }
}
