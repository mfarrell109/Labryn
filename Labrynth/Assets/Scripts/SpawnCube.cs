using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject RedCube;
    public GameObject GreenCube;
    public GameObject BlueCube;
    private GameObject[] CloneRed;
    private GameObject[] CloneBlue;
    private GameObject[] CloneGreen;
    private int playerDiceCount;
    private int priLoc, secLoc;
    private int beginSpawnPoint;
    private int endSpawnPoint;
    private int redLoc;
    private int greenLoc;
    private int blueLoc;
    private int classLoc;
    private int levelLoc;
    private int redAmount, greenAmount, blueAmount, levelAmount, classAmount;
    private int maxNumDice;
    private int minNumDice;
    private static int diceTotal, monsterDiceTotal;

    private BaseDIeModel DisplayDie;

    // Use this for initialization       
    public GameObject ClassCube;
    public GameObject LevelCube;
    private GameObject[] CloneClassCube;
    private GameObject[] CloneLevelCube;
    // Use this for initialization
    void Start()
    {
        DisplayDie = GetComponent<BaseDIeModel>();
        RedCube.GetComponent<Rigidbody>();
        BlueCube.GetComponent<Rigidbody>();
        GreenCube.GetComponent<Rigidbody>();
        ClassCube.GetComponent<Rigidbody>();
        LevelCube.GetComponent<Rigidbody>();
        priLoc = 9;
        secLoc = 9;
        beginSpawnPoint = 9;
        endSpawnPoint = 18;
        diceTotal = 0;

    }

    public int getDiceTotal()
    {
        return diceTotal;
    }

    // Update is called once per frame
    void Update()
    {
        
        CloneBlue = GameObject.FindGameObjectsWithTag("BlueDice");
        CloneGreen = GameObject.FindGameObjectsWithTag("GreenDice");
        CloneRed = GameObject.FindGameObjectsWithTag("RedDice");
        CloneClassCube = GameObject.FindGameObjectsWithTag("ClassDice");
        CloneLevelCube = GameObject.FindGameObjectsWithTag("LevelDice");

        redAmount = CloneRed.Length - 1;
        greenAmount = CloneGreen.Length - 1;
        blueAmount = CloneBlue.Length - 1;
        classAmount = CloneClassCube.Length - 1;
        levelAmount = CloneLevelCube.Length - 1;
        diceTotal = redAmount + greenAmount + blueAmount;
        maxNumDice = 0;
        minNumDice = -1;     

    }



    public void spawnRed()
    {    
        if(priLoc <= endSpawnPoint && (redLoc < 3))
        {
            IncrementPlayerDice(RedCube, priLoc);
            redLoc++;
            priLoc = priLoc + 3;
        }
        else
        {
            Debug.Log("Can't spawn more red cubes");
        }
    }

    public void spawnGreen()
    {
        if (priLoc <= endSpawnPoint && (greenLoc < 3))
        {
            //priLoc = 3;
            IncrementPlayerDice(GreenCube, priLoc);
            greenLoc++;
            priLoc = priLoc + 3;

        }
        else
        {
            Debug.Log("Can't spawn more green cubes");
        }
    }

    public void spawnBlue()
    {
        if (priLoc <= endSpawnPoint && (blueLoc < 3))
        {
            //priLoc = 3;
            IncrementPlayerDice(BlueCube, priLoc);
            blueLoc++;
            priLoc = priLoc + 3;
        }
        else
        {
            Debug.Log("Can't spawn more blue cubes");
        }
    }

    public void destroyRed()
    {
        if (priLoc > beginSpawnPoint && redLoc > 0)
        {
            decrementPlayerDice(CloneRed, redAmount);
            priLoc = priLoc - 3;
            redLoc--;
        }
        else
        {
            Debug.Log("Can't destroy more red cubes");
        }
    }

    public void destroyBlue()
    {
        if (priLoc > beginSpawnPoint && blueLoc > 0)
        {
            decrementPlayerDice(CloneBlue, blueAmount);
            priLoc = priLoc - 3;
            blueLoc--;
        }
        else
        {
            Debug.Log("Can't destroy more blue cubes");
        }
    }

    public void destroyGreen()
    {
        if (priLoc > beginSpawnPoint && greenLoc > 0)
        {
            decrementPlayerDice(CloneGreen, greenAmount);
            priLoc = priLoc - 3;
            greenLoc--;
        }
        else
        {
            Debug.Log("Can't destroy more green cubes");
        }
    }

    public void spawnLevelDice()
    {
        if (secLoc <= endSpawnPoint && (classLoc < 3))
        {
            IncrementPlayerDice(ClassCube, priLoc);
            classLoc++;
            secLoc = secLoc + 3;
        }
        else
        {
            Debug.Log("Can't spawn more red cubes");
        }
    }

    public void spawnClassDice()
    {
        if (secLoc <= endSpawnPoint && (classLoc < 3))
        {
            IncrementPlayerDice(RedCube, priLoc);
            classLoc++;
            secLoc = secLoc + 3;
        }
        else
        {
            Debug.Log("Can't spawn more red cubes");
        }
    }


    public void IncrementPlayerDice(GameObject sCube, int loc)
    {
        try
        {
            if (diceTotal < maxNumDice)
            {
                Instantiate(sCube , new Vector3(loc, 19, 0), Quaternion.Euler(0, 0, 0));
                
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

    private void decrementPlayerDice(GameObject[] sCube, int diceAmount )
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
            Debug.Log("decrementPlayerDice Error: " + e.Message);
        }
    }

    public void destroyAllDice()
    {
        priLoc = 9;
        redLoc = 0;
        greenLoc = 0;
        blueLoc = 0;
        //nextRound = true;

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

        DisplayDie.resetDiceSums(0,0,0, 0, 0);
        
    }

    //Method used to destroy all monster dice
    public void destroyAllMonsterDice()
    {

    }
}
