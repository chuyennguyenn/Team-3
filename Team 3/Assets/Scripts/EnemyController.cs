using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;

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
            // Calculate the direction to the target
            Vector2 direction = target.position - transform.position;
            direction.Normalize();

            // Move the enemy towards the target
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

}
