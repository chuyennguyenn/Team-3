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
    public Animator animator;
    public bool isFacingRight;

    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
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

        if (dialogueUI.isOpen)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }

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
