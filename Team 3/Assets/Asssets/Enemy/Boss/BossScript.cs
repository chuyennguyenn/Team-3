using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private BossAnimator agentAnimations;
    private BossMover agentMover;
    private Healthbar healthbar;

    private Vector2 pointerInput, movementInput;

    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }
    private bool isAlive = true;
    [SerializeField]float health,maxHealth = 500f;

    private void Start()
    {
        health = maxHealth;
        healthbar = FindObjectOfType<Healthbar>();
        healthbar.SetMaxHealth(maxHealth);
    }

    public void UpdateHealth(float mod)
    {
        health += mod;
        if(health > maxHealth)
        {
            health = maxHealth;
        }else if (health <= maxHealth)
        {
            health = 0f;
            Die();
        }
        healthbar.SetHealth(health);

    }

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


    }
    

    public void PerformAttack()
    {

        // Randomly choose an attack
        int attackType = Random.Range(1, 3); // Assuming 1, 2, 3, spatk as different attacks
        agentAnimations.TriggerAttack(attackType);
        Debug.Log("PerformAttack: Triggered attack of type " + attackType);

    }

    private void Awake()
    {
        agentAnimations = GetComponentInChildren<BossAnimator>();
        agentMover = GetComponent<BossMover>();
    }
    
    public void TakeDamage(float damage)
    {
        agentAnimations.TriggerTakeHit();
        // Reduce health or trigger damage effects
        health -= damage;
        if (health <= 0)
        {
            healthbar.SetHealth(health);
            Die(); // Or any method to handle boss death
        }
        else
        {
            healthbar.SetHealth(health);
        }
       }
    
    public void Die() 
    {
        if (!isAlive)
            return;
        agentMover.enabled = false;
        isAlive = false;

        agentAnimations.TriggerFrozen();

        // Disable movement and attacks
        agentMover.enabled = false;
        // Additional death logic, like stopping movement, disabling collisions, etc.
        StopAllCoroutines();
    }

    private void AnimateCharacter()
    {
        if (!isAlive)
            return;
        Vector2 lookDirection = pointerInput - (Vector2)transform.position;
        agentAnimations.RotateToPointer(lookDirection);
        agentAnimations.PlayAnimation(MovementInput);
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("bullet2"))
        {
            TakeDamage(500);
            Die(); // Trigger frozen state and set alive to false
        }
        else
        {
            TakeDamage(2); // Handle regular hit
        }
    }
}
