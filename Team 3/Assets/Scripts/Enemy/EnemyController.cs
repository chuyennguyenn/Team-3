using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    private float _health;
    private float _maxHealth=4;
    Animator animator;

    bool isAlive = true;

    private void Start()
    {
        _health = _maxHealth;
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
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
                }
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

        private void Update()
        {
            // If there is a target, move towards it
            if (target != null)
            {
                Vector2 direction = target.position - transform.position;
                direction.Normalize();

            if (_health < _maxHealth / 2)
                 {
                        // Move the enemy away from the target
                    Vector2 oppositeDirection = (Vector2)transform.position - direction;
                    transform.position = Vector2.MoveTowards(transform.position, oppositeDirection, speed * Time.deltaTime);
                    }
                else
                     {
                // Move the enemy towards the target
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                }
        
            }

        }

  }
