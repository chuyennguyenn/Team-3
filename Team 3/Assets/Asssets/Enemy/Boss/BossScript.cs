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
    [SerializeField]public static float health,maxHealth = 1000f;

    private Transform playerTransform;

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
        //int attackType = Random.Range(1, 3); // Assuming 1, 2, 3, spatk as different attacks
        // Get the player's position
        Vector2 playerPosition = playerTransform.position;
        Vector2 directionToPlayer = playerPosition - (Vector2)transform.position;
        directionToPlayer.Normalize();
        int attackType;
        if (Mathf.Abs(directionToPlayer.y) > Mathf.Abs(directionToPlayer.x) )
        {

            // Closer to up or down, so play Hit4
            attackType = 2;
            agentAnimations.TriggerAttack(attackType);
            Debug.Log("PerformAttack: Triggered attack of type spatk");
        }
        else
        {
            // Closer to left or right, so play Hit3
            attackType = 1;
            agentAnimations.TriggerAttack(attackType);
            Debug.Log("PerformAttack: Triggered attack of type punch slam");
        }

        // Apply damage to the player
        PlayerHP playerHP = playerTransform.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            playerHP.takeDMG(30, transform.position, 50f); // 50 damage and knockback force of 5f
            Debug.Log("PerformAttack: Dealt 50 damage to the player");
        }



        Debug.Log("PerformAttack: Triggered attack of type " + attackType);

    }

    private void Awake()
    {
        agentAnimations = GetComponentInChildren<BossAnimator>();
        agentMover = GetComponent<BossMover>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Debug.Log("player transformed");
            playerTransform = playerObject.transform;
        }
        else {
            Debug.Log("player not transformed");
        }
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
            TakeDamage(1001);
            Die(); // Trigger frozen state and set alive to false
        }
        else
        {
            TakeDamage(2); // Handle regular hit
        }
    }
}
