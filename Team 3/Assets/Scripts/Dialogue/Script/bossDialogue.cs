using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDialogue : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject DialogueObject;

    public void Interact(PlayerCtrlV2 player)
    {
        player.DialogueUI.ShowDialogue(DialogueObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.TryGetComponent(out PlayerCtrlV2 player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.TryGetComponent(out PlayerCtrlV2 player) && BossScript.health <= 0)
        {
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
            }
        }
    }
}
