using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrlV2 : MonoBehaviour
{
    public float MS;
    float spdX, spdY;
    private float Move;
    private Rigidbody2D rb;
    
    public coinMNG cm;
    public ShootingV2 shooting;
    private Animator animator;
    private bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        spdX = Input.GetAxisRaw("Horizontal") * MS;
        spdY = Input.GetAxisRaw("Vertical") * MS;
        rb.velocity = new Vector2(spdX,spdY);
        Move = Input.GetAxisRaw("Horizontal");

        if(!isFacingRight && Move > 0){
            Flip();
        } else if(isFacingRight && Move <0){
            Flip();
        }

        if(spdX != 0 || spdY != 0){
            animator.SetBool("isMoving",true);
        }else{
            animator.SetBool("isMoving",false);
        }
        // if(shooting.canFire)
        //     {animator.SetTrigger("ATK");}
        
    }   
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("coin")){
            Destroy(other.gameObject);
            cm.coinCount ++;
        }
    }

    public void Flip(){
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
