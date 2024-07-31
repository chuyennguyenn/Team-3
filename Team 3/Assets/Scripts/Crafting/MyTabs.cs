using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Code from youtube video: https://www.youtube.com/watch?v=WCRxA3kB584
public class MyTabs : MonoBehaviour
{
    public GameObject tabButton1;
    public GameObject tabButton2;
    public GameObject tabButton3;

    public GameObject tabContent1;
    public GameObject tabContent2;
    public GameObject tabContent3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideAllTabs() 
    {
        tabContent1.SetActive(false);
        tabContent2.SetActive(false);
        tabContent3.SetActive(false);

        tabButton1.GetComponent<Button>().image.color = new Color32(212, 212, 212, 255);
        tabButton2.GetComponent<Button>().image.color = new Color32(212, 212, 212, 255);
        tabButton3.GetComponent<Button>().image.color = new Color32(212, 212, 212, 255);
    }

    public void ShowTab1() 
    {
        HideAllTabs();
        tabContent1.SetActive(true);
        tabButton1.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
    }
    public void ShowTab2() 
    {
        HideAllTabs();
        tabContent2.SetActive(true);
        tabButton2.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
    }
    public void ShowTab3() 
    {
        HideAllTabs();
        tabContent3.SetActive(true);
        tabButton3.GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
    }
}
