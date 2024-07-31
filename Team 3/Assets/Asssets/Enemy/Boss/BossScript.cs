using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private BossAnimator agentAnimations;
    private BossMover agentMover;

    private Vector2 pointerInput, movementInput;

    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }
    private bool isAlive = true;

    private void Update()
    {
        if (!isAlive)
        {
            return;
        }
        //pointerInput = GetPointerInput();
        //movementInput = movement.action.ReadValue<Vector2>().normalized;

        agentMover.MovementInput = MovementInput;
        
        AnimateCharacter();

        if (agentAnimations.IsInState("Entrance"))
        {
            agentAnimations.SetEntrance(false);
        }
    }

    public void PerformAttack()
    {
        if (!isAlive) return;

        // Randomly choose an attack
        int attackType = Random.Range(1, 4); // Assuming 1, 2, 3, spatk as different attacks
        agentAnimations.TriggerAttack(attackType);
    }

    private void Awake()
    {
        agentAnimations = GetComponentInChildren<BossAnimator>();
        agentMover = GetComponent<BossMover>();
    }

    public void TakeDamage()
    {
        if (!isAlive) return;

        agentAnimations.TriggerTakeHit();
    }
    
    public void Die() {
    isAlive = false;
    agentAnimations.TriggerFrozen();
    // Additional death logic, like stopping movement, disabling collisions, etc.
    }

    private void AnimateCharacter()
    {
        Vector2 lookDirection = pointerInput - (Vector2)transform.position;
        agentAnimations.RotateToPointer(lookDirection);
        agentAnimations.PlayAnimation(MovementInput);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet2"))
        {
            Die(); // Trigger frozen state and set alive to false
        }
        else
        {
            TakeDamage(); // Handle regular hit
        }
    }
}
