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
}
