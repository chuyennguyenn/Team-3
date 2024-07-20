using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{   
    public GameObject bulletPrefab;
    public Transform firePoint;
    // Vector2 mousePosition;
    // public Rigidbody2D rb;
    public float fireForce = 20f;
    // Start is called before the first frame update
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
    // private void FixedUpdate(){
    //     mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     Vector2 aimDirection = mousePosition- rb.position;
    //     float aimAngle = Mathf.Atan2(aimDirection.y , aimDirection.x) * Mathf.Rad2Deg - 90f;
    //     rb.rotation = aimAngle;
    // }
    // Update is called once per frame
    void Update()
    {
        
    }
}
