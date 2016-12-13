﻿using UnityEngine;
using System.Collections;
using System;
using System.Linq;

/*
 * This script was created to apply attributes regarding physics to dice 
 */
public class DiceMovement : MonoBehaviour {


    public LayerMask dieValueColliderLayer = -1;
    //public string buttonName = "Fire1";
    public ForceMode forceMode;
    public Font greekfont;
    RaycastHit hit;
    private GUIStyle guiStyle = new GUIStyle();
    private GameObject[] RedTotal;
    private GameObject[] BlueTotal;
    private GameObject[] GreenTotal;
    BaseDieModel DisplayDie = new BaseDieModel();
    
    void Start ()
    {

        BlueTotal = GameObject.FindGameObjectsWithTag("BlueDice");
        GreenTotal = GameObject.FindGameObjectsWithTag("GreenDice");
        RedTotal = GameObject.FindGameObjectsWithTag("RedDice");

        guiStyle.fontSize = 32;
        guiStyle.normal.textColor = Color.red;
        guiStyle.font = greekfont;
    }
	
	// Update is called once per frame
	void Update () {
    }

    /**
     * This method is used to give dice movement(force and torque)
     * **/
    public void moveDice()
    {
        BlueTotal = GameObject.FindGameObjectsWithTag("BlueDice");
        GreenTotal = GameObject.FindGameObjectsWithTag("GreenDice");
        RedTotal = GameObject.FindGameObjectsWithTag("RedDice");

        //resetting each color dice total
        resetDiceSums();

        try
        {
            Invoke("UpdateDiceMovement", 3f);

            foreach (GameObject Die in (BlueTotal))
            {
                Die.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * DisplayDie.getForce(), forceMode);
                Die.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * DisplayDie.getTorque(), forceMode);
            }
            foreach (GameObject Die in (RedTotal))
            {
                Die.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * DisplayDie.getForce(), forceMode);
                Die.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * DisplayDie.getTorque(), forceMode);                
            }
            foreach (GameObject Die in (GreenTotal))
            {
                Die.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * DisplayDie.getForce(), forceMode);
                Die.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * DisplayDie.getForce(), forceMode);                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /**
     * This method controls when the dice collides and what happens after that point. 
     * Getting proper values to display from each individual dice and calculating the result from each color
     * **/
    private void UpdateDiceMovement()
    {
        //GUI.DrawTexture(new Rect(10, 10, 60, 60), aTexture, ScaleMode.ScaleToFit, true, 10.0F);


        Invoke("updateYellowFont", .3f);
        Invoke("updateRedFont", .6f);
        Invoke("updateYellowFont", .9f);
        Invoke("updateRedFont", 1.2f);

        foreach (GameObject Red in RedTotal)
        {
          
            if (Physics.Raycast(Red.transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer) && 
                (Red.GetComponent<Rigidbody>().velocity == Vector3.zero) &&
                (Red.GetComponent<Rigidbody>().angularVelocity == Vector3.zero))
            {
                DisplayDie.setRedValue(hit.collider.GetComponent<DieValue>().value);
                DisplayDie.setRedSum(DisplayDie.getRedSum() + DisplayDie.getRedValue());
                
            }
        }

        foreach (GameObject Blue in BlueTotal)
        {
            if (Physics.Raycast(Blue.transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer) &&
                (Blue.GetComponent<Rigidbody>().velocity == Vector3.zero) &&
                (Blue.GetComponent<Rigidbody>().angularVelocity == Vector3.zero))
            {
                DisplayDie.setBlueValue(hit.collider.GetComponent<DieValue>().value);
                DisplayDie.setBlueSum(DisplayDie.getBlueSum() + DisplayDie.getBlueValue());
            }
        }
        foreach (GameObject Green in GreenTotal)
        {
            if (Physics.Raycast(Green.transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer) &&
                (Green.GetComponent<Rigidbody>().velocity == Vector3.zero) &&
                (Green.GetComponent<Rigidbody>().angularVelocity == Vector3.zero))
            {
                DisplayDie.setGreenValue(hit.collider.GetComponent<DieValue>().value);
                DisplayDie.setGreenSum(DisplayDie.getGreenSum() + DisplayDie.getGreenValue());
            }
        }

        
    }      
    
    private void updateYellowFont()
    {
        guiStyle.normal.textColor = Color.yellow;
        Debug.Log( "Yellow Count: ");
    }  

    private void updateRedFont()
    {
        guiStyle.normal.textColor = Color.red;
        Debug.Log("Red Count: ");
    }

    public void resetDiceSums()
    {
        DisplayDie.setRedSum(0);
        DisplayDie.setBlueSum(0);
        DisplayDie.setGreenSum(0);
    }

    
    /**
     * Labels to display for dice roll. Getting calculated values using the BaseDieModel
     **/
    void OnGUI()
    {
        //GUILayout.Label(new Rect(10, 10, 100, 20), DisplayDie.getBlueDiceName() + ": " + DisplayDie.getBlueSum());
        //GUI.contentColor = Color.black;
        //GUI.DrawTexture(new Rect(100, 10, 100, 20), atexture, ScaleMode.ScaleToFit, true, 10.0F);
        GUI.Label(new Rect(10, 10, 100, 20) , DisplayDie.getBlueDiceName() +  ": " + DisplayDie.getBlueSum(), guiStyle);
        GUI.Label(new Rect(10, 40, 100, 20), DisplayDie.getRedDiceName() + ": " + DisplayDie.getRedSum(),guiStyle);
        GUI.Label(new Rect(10, 70, 100, 20), DisplayDie.getGreenName() + ": "  + DisplayDie.getGreenSum(), guiStyle);
    }

}
