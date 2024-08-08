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

    }

    public void takeDMG (float dmg){
        HP -= dmg;
        if (IsInvincible)
        {
            return;
        }
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
