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

    public void SetEntrance(bool entrance)
    {
        animator.SetBool("entrance", entrance);
    }

    public void SetMoving(bool isMoving)
    {
        animator.SetBool("isMoving", isMoving);
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

    }

    public void TriggerAttack(int attackType)
    {
        switch (attackType)
        {
            case 1:
                animator.SetTrigger("Hit1");
                break;
            case 2:
                animator.SetTrigger("Hit2");
                break;
            case 3:
                animator.SetTrigger("Hit3");
                break;
            case 4:
                animator.SetTrigger("Spatk");
                break;
        }
    }

    public void TriggerTakeHit()
    {
        animator.SetTrigger("TakeHit");
    }

    public void TriggerFrozen()
    {
        animator.SetBool("Frozen", true);
    }

}
