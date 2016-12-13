using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour {

    public GameObject RedCube;
    public GameObject GreenCube;
    public GameObject BlueCube;
    private GameObject[] CloneRed;
    private GameObject[] CloneBlue;
    private GameObject[] CloneGreen;
    private int playerDiceCount;
    private int redloc, greenloc, blueloc;
    private int redAmount, greenAmount, blueAmount;
    private int maxNumDice;
    private int minNumDice;
    private int diceTotal;
    private Boolean nextRound = false;

    BaseDieModel DisplayDie = new BaseDieModel();

    // Use this for initialization
    void Start () {        

    }

    // Update is called once per frame
    void Update()
    {
        CloneBlue = GameObject.FindGameObjectsWithTag("BlueDice");
        CloneGreen = GameObject.FindGameObjectsWithTag("GreenDice");
        CloneRed = GameObject.FindGameObjectsWithTag("RedDice");
        redloc = 5;
        greenloc = 10;
        blueloc = 15;
        redAmount = CloneRed.Length - 1;
        greenAmount = CloneGreen.Length - 1;
        blueAmount = CloneBlue.Length - 1;
        diceTotal = redAmount + greenAmount + blueAmount;
        maxNumDice = 0;
        minNumDice = -1;

    }

    public void spawnRed()
    {
        IncrementDice(RedCube, redloc );   
    }

    public void spawnGreen()
    {
        IncrementDice(GreenCube, greenloc);
    }

    public void spawnBlue()
    {
        IncrementDice(BlueCube, blueloc);
    }

    public void destroyRed()
    {
        decrementDice(CloneRed, redAmount);
    }

    public void destroyBlue()
    {
        decrementDice(CloneBlue, blueAmount);
    }

    public void destroyGreen()
    {
        decrementDice(CloneGreen, greenAmount);
    }

    public void IncrementDice(GameObject sCube, int loc)
    {
        try
        {
            if (diceTotal < maxNumDice)
            {
                Instantiate(sCube , new Vector3(loc, 5, 0), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                Debug.Log("You have the max amount of dice already. Please make another selection");
            }
        }
        catch (Exception e)
        {
            Debug.Log("SpawnDice Error: " + e.Message);
        }
    }

    private void decrementDice(GameObject[] sCube, int diceAmount )
    {
        try
        {
            if (diceAmount > minNumDice)
            {
                Destroy(sCube[diceAmount]);
            }
            else
            {
                Debug.Log("You have 0 dice already. Please make a selection");
            }
        }
        catch (Exception e)
        {
            Debug.Log("decrementDice Error: " + e.Message);
        }
    }

    public void destroyAllDice()
    {
        nextRound = true;

        foreach (GameObject cloneR in CloneRed )
        {
            Destroy(cloneR);
        }
        foreach (GameObject cloneB in CloneBlue)
        {
            Destroy(cloneB);
        }
        foreach (GameObject cloneG in CloneGreen)
        {
            Destroy(cloneG);
        }

        DisplayDie.resetDiceSums(0,0,0);
        
    }








}
