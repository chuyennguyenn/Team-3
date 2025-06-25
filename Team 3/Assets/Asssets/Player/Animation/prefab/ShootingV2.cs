using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingV2 : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    int bulletType = 1;
    public GameObject bullet1;
    public GameObject bullet2;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public Animator animator;
    public PlayerCtrlV2 player;
    public float rotZ;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        GameObject bullet = bullet1;
        Animator animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        if(!player.isFacingRight){
            rotZ = Mathf.Atan2(-rotation.y, -rotation.x) * Mathf.Rad2Deg;
        } else if(player.isFacingRight){
            rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0,0,rotZ);
        
        if(!canFire){
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring){
                animator.ResetTrigger("ATK");
                canFire = true;
                timer = 0;
            }
        }
        
        if(Input.GetKeyDown("1")){
            bulletType = 1;
        }
        if(Input.GetKeyDown("2")){
            bulletType = 2;
        }
        if(Input.GetMouseButton(0) && canFire){
            animator.SetTrigger("ATK");
            canFire = false;
            if(bulletType == 1)
                {
                Instantiate(bullet1, bulletTransform.position, Quaternion.identity);
                // Destroy(bullet1,1);
                }
                
            if(bulletType == 2)
                {Instantiate(bullet2, bulletTransform.position, Quaternion.identity);}

            
        }
    }
    // public void atk(){
    //     animator.SetBool("isATK",false);
    // }
}
