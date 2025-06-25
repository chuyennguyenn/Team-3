using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable{  get;  set; }

    public float MS;

    float spdX, spdY;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueUI.isOpen)
        {
            return;
        }

        spdX = Input.GetAxisRaw("Horizontal") * MS;
        spdY = Input.GetAxisRaw("Vertical") * MS;
        rb.velocity = new Vector2(spdX, spdY);

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (Interactable != null)
            {
                //Interactable.Interact(this);
            }
        }
    }
}
