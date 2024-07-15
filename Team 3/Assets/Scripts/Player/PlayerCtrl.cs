using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public coinMNG cm;
    public float MS;
    private bool _isMoving = false;
    // public bool isMoving { get{
    //     return _isMoving;
    // } private set{
    //     _isMoving = value;
    //     animator.SetBool("isMoving", value)
    // }}
    float spdX, spdY;
    Rigidbody2D rb;
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
        spdX = Input.GetAxisRaw("Horizontal") * MS;
        spdY = Input.GetAxisRaw("Vertical") * MS;
        rb.velocity = new Vector2(spdX,spdY);
    }
    // public void OnMove(InputAction.CallbackContext context){
    //     moveInput = context.ReadValue<Vector2>();
    //     isMoving = moveInput != Vector2.zero;
    // }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("coin")){
            Destroy(other.gameObject);
            cm.coinCount ++;
        }
    }
}
