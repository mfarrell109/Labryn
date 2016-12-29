using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanels : MonoBehaviour {

    public GameObject gamePanel;
    public GameObject childPanel1;
    public GameObject childPanel2;
    private bool isUp;
    
    // Use this for initialization
    void Start()
    {        
        gamePanel.GetComponent<GameObject>();
        childPanel1.GetComponent<GameObject>();
        childPanel2.GetComponent<GameObject>();

        gamePanel.SetActive(false);
        childPanel1.SetActive(false);
        childPanel2.SetActive(false);
    }

    void Update()
    {
        gamePanel.GetComponent<GameObject>();
        childPanel1.GetComponent<GameObject>();
        childPanel2.GetComponent<GameObject>();

    }

    public void turnOnRollPanel1()
    {
        childPanel2.SetActive(false);
        childPanel1.SetActive(true);
        gamePanel.SetActive(true);
    }

    public void turnOffRollPanel1()
    {
        gamePanel.SetActive(false);
        childPanel1.SetActive(false);        

    }

    public void turnOnRollPanel2()
    {
        childPanel1.SetActive(false);
        childPanel2.SetActive(true);
        gamePanel.SetActive(true);

    }

    public void turnOffRollPanel2()
    {
        childPanel2.SetActive(false);
        gamePanel.SetActive(false);
    }
}
