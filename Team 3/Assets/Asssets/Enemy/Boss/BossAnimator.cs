using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    private Animator animator;
    private Vector3 originalScale;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;

    }

    public bool IsInState(string stateName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    public void SetEntrance(bool active)
    {
        animator.SetBool("entrance", active);
    }

    public void RotateToPointer(Vector2 lookDirection)
    {
        Vector3 scale = originalScale;
        if (lookDirection.x > 0)
        {
            scale.x = Mathf.Abs(originalScale.x);
        }
        else if (lookDirection.x < 0)
        {
            scale.x = -Mathf.Abs(originalScale.x);
        }
        transform.localScale = scale;
    }

    public void PlayAnimation(Vector2 movementInput)
    {
        animator.SetBool("isMoving", movementInput.magnitude > 0);
        Debug.Log("PlayAnimation: isMoving = " );

    }

    public void TriggerAttack(int attackType)
    {
        animator.SetBool("isAttacking",true);
        switch (attackType)
        {  
            case 1:
                animator.SetTrigger("Hit3");
                break;
            case 2:
                animator.SetTrigger("Hit4");
                break;
        }
        Debug.Log("triggered atk");
    }
    
    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
    }


    public void TriggerTakeHit()
    {
        animator.SetTrigger("TakeHit");
    }

    public void TriggerFrozen()
    {
        animator.SetBool("Frozen", true);
        animator.SetBool("isAlive", false);

    }

}
