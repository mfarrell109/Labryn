using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanels : MonoBehaviour {

    public GameObject gamePanel;
    // Use this for initialization
    void Start()
    {
        
        //gamePanel.GetComponent<GameObject>();
        //gamePanel = GameObject.FindGameObjectWithTag("Stuck");
        GameObject.Find("Modal Panel");
        gamePanel.SetActive(false);
        //turnOnRollPanel();
    }

    public void turnOnRollPanel()
    {
        //gamePanel.GetComponent<GameObject>();
        gamePanel.SetActive(true);
    }

    public void turnOffRollPanel()
    {
        //gamePanel.GetComponent<GameObject>();
        gamePanel.SetActive(false);
    }



}
