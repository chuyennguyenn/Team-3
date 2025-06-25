using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDMGed : MonoBehaviour
{
    public PlayerHP pHP;
    // public Enemy enemy;
    public float dmg;
    public float heal;
    // Start is called before the first frame update
    [SerializeField]
    private float _invincibilityDuration;

    private Invincibility _invincibilityController;

    private void Awake()
    {
        _invincibilityController = GetComponent<Invincibility>();    
    }

    public void StartInvincibility()
    {
        _invincibilityController.StartInvincibility(_invincibilityDuration);
    }

}
