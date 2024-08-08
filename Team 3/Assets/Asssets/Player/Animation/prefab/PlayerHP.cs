using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class PlayerHP : MonoBehaviour
{
    public float HP;
    public float maxHP;
    public Image HPbar;
    private float timer;
    public float timeToExit;
    public Animator animator;
    public PlayerCtrlV2 player;
    public GameOverScreen KOscreen;

    private bool isKnockedBack;
    private float knockbackTimer;
    public float knockbackDuration = 0.5f; // Adjust as needed
    private Vector2 knockbackDirection;

    [SerializeField] 
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        Animator animator = player.GetComponent<Animator>();
        animator.SetBool("isDead",false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0){
            HP = 0;
        }
        if(HP > maxHP){
            HP = maxHP;
        }
        HPbar.fillAmount = Mathf.Clamp(HP / maxHP, 0 , 1);

        if (isKnockedBack)
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer <= 0)
            {
                isKnockedBack = false;
                rb2d.velocity = Vector2.zero; // Stop the knockback movement
            }
        }

    }

    public void takeDMG (float dmg,Vector2 attackerPosition, float knockbackForce)
    {
        Debug.Log("takeDMG called with damage: " + dmg + ", attackerPosition: " + attackerPosition + ", knockbackForce: " + knockbackForce);
        HP -= dmg;
        if (IsInvincible)
        {
            return;
        }

        ApplyKnockback(attackerPosition, knockbackForce);

        if (HP <= 0){
            HP = 0;
            OnDied.Invoke();
            animator.SetBool("isDead2",true);
            timer += Time.deltaTime;
            if(timer > timeToExit){
                KOscreen.Setup();
            }
        }
        
        else{
            OnDamaged.Invoke();
        }
    }

    private void ApplyKnockback(Vector2 attackerPosition, float knockbackForce)
    {
        Debug.Log("ApplyKnockback called with attackerPosition: " + attackerPosition + ", knockbackForce: " + knockbackForce);
        isKnockedBack = true;
        knockbackTimer = knockbackDuration;
        Vector3 attackerPosition3D = new Vector3(attackerPosition.x, attackerPosition.y, 0f);
        knockbackDirection = (transform.position - attackerPosition3D).normalized;
        rb2d.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

    }

    public void healing (float heal){
        HP += heal;
        if (HP >= maxHP){
            HP = maxHP;
            return;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;
}
