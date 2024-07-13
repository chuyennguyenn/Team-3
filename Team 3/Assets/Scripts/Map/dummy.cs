using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy : MonoBehaviour
{

    public float MS;
    private bool _isMoving = false;
    public float forced;
    //public Rigidbody2D rb;
    // public bool isMoving { get{
    //     return _isMoving;
    // } private set{
    //     _isMoving = value;
    //     animator.SetBool("isMoving", value)
    // }}
    float spdX, spdY;
    Rigidbody2D rb;
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
        rb.velocity = new Vector2(spdX, spdY);
    }
    // public void OnMove(InputAction.CallbackContext context){
    //     moveInput = context.ReadValue<Vector2>();
    //     isMoving = moveInput != Vector2.zero;
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        rock player = other.GetComponent<rock>();

    }
}
