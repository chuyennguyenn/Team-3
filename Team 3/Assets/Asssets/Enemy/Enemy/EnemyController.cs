using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    [SerializeField] private float _health;
    [SerializeField] public float _maxHealth=10;
    private EnemyHealthbar healthbar;
    Animator animator;
    private Vector2 randomTarget;
    private float changeDirectionTime = 2f;
    private float timeSinceDirectionChange;

    bool isAlive = true;
    bool isMoving = false;

    private void Start()
    {
        _health = _maxHealth;
        animator = GetComponent<Animator>();
        healthbar = FindObjectOfType<EnemyHealthbar>();
        healthbar.SetMaxHealth(_maxHealth);
        animator.SetBool("isAlive", isAlive);
        animator.SetBool("isMoving", isMoving);

    }

    public float Health
    {
            set
            {
            if (value < _health)
            {
                animator.SetTrigger("hit");
            }

            _health = value;


            if (_health <= 0)
                {
                   animator.SetBool("isAlive", false);
                    Die();
                }
            healthbar.SetHealth(_health);
        }
    }

    public void TakeDamage(float damage)
    {
        animator.SetTrigger("hit");
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            healthbar.SetHealth(_health);
            Die();
        }
        else
        {
            healthbar.SetHealth(_health);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                target = other.transform;

                Debug.Log("Player entered the radius: " + target);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            // Check if the object exiting the trigger is tagged as "Player"
            if (other.gameObject.CompareTag("Player"))
            {
                // Clear the target when the player exits the radius
                target = null;

                // Log a message indicating the player has exited the radius
                Debug.Log("Player exited the radius");
            }


        }
    private void Die()
    {
        GetComponent<LootBag>().InsanLoot(transform.position);
        Destroy(gameObject);
    }


    private void detemisticMover(Vector2 targetPosition)
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        bool flipped = direction.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

        if (direction != Vector2.zero)//(0,0)
        {
            var xMovement = direction.x * speed * Time.deltaTime;
            this.transform.Translate(new Vector3(xMovement, 0), Space.World);

        }

        if (_health < _maxHealth / 2)
        {
            // Move the enemy away from the target
            Vector2 oppositeDirection = (Vector2)transform.position - direction;
            oppositeDirection.Normalize();
            transform.position = Vector2.MoveTowards(transform.position, oppositeDirection, speed * Time.deltaTime);
        }
        else
        {
            // Move the enemy towards the target
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
    }

        private void PickRandomDirection()
        {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        randomTarget = (Vector2)transform.position + randomDirection * 5f;
        }

        private void moveRandomly(){

        timeSinceDirectionChange += Time.deltaTime;
        if (timeSinceDirectionChange >= changeDirectionTime){
            PickRandomDirection();
             timeSinceDirectionChange = 0f;
        }

         Vector2 direction = randomTarget - (Vector2)transform.position;
         if (direction.magnitude < 0.1f)
            {
                PickRandomDirection();
            }
            else
                {
                direction.Normalize();
                bool flipped = direction.x < 0;
                transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

                transform.position = Vector2.MoveTowards(transform.position, randomTarget, speed * Time.deltaTime);
                }
         }

        private void Update()
        {
            // If there is a target, move towards it
            if (target != null)
            {
            detemisticMover(target.position);
            animator.SetBool("isMoving", true);// run at enemy

        }
        else
            {
            animator.SetBool("isMoving", false);//idle walk 
            moveRandomly();
        }


        }

  }
