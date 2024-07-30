using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //projectile
    public weapon wp;
    Vector2 moveDirection;
    Vector2 mousePosition;
    public float bulletSpeed = 3;
    public coinMNG cm;
    public float MS;
    private bool _isMoving = false;
    public int health;
    // public bool isMoving { get{
    //     return _isMoving;
    // } private set{
    //     _isMoving = value;
    //     animator.SetBool("isMoving", value)
    // }}
    float spdX, spdY;
    public Rigidbody2D rb;
    Animator animator;
    // private void Awake(){
    //     rb = GetComponent<Rigidbody2D>();
    //     animator = GetComponent<Animator>();
    // }
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // movement
        spdX = Input.GetAxisRaw("Horizontal") * MS;
        spdY = Input.GetAxisRaw("Vertical") * MS;
        

        // projectile
        if(Input.GetKeyDown(KeyCode.Space)){
            wp.Fire();
        }
// Input.GetMouseButtonDown(0)
        moveDirection = new Vector2(spdX,spdY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
    private void FixedUpdate(){
        rb.velocity = new Vector2(spdX,spdY);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y , aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("coin")){
            Destroy(other.gameObject);
            cm.coinCount ++;
        }
    }
}
