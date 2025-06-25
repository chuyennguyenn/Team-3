using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy : MonoBehaviour
{

    public float MS;
    private bool _isMoving = false;
    public float forced;
    public static int health;
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
        health = 10;

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
        rb.velocity = new Vector2(spdX, spdY);
        if (Input.GetKeyDown("u"))
        {
            Debug.Log("health is " + health);
        }

        if (Input.GetKeyDown("i"))
        {
            transform.position = new Vector2(105, 191);
        }
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
