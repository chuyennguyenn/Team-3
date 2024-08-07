using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Control : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float force1;
    public float dmg1;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos ;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force1;
        float rot = Mathf.Atan2(rotation.y , rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            // Apply damage or other effects
            other.gameObject.GetComponent<BossScript>().TakeDamage(dmg1); // Assuming BossControl has TakeDamage method
            Destroy(gameObject); // Destroy bullet on collision
        }
        if (other.CompareTag("Enemy"))
        {
            // Apply damage or other effects
            other.gameObject.GetComponent<EnemyController>().TakeDamage(dmg1); // Assuming BossControl has TakeDamage method
            Destroy(gameObject); // Destroy bullet on collision
        }
    }
}
