using UnityEngine;
using System.Collections;
using System;
using System.Linq;

/*
 * This script was created to apply attributes regarding physics to dice 
 */
public class DiceMovement : BaseDIeModel {


    public LayerMask dieValueColliderLayer = -1;
    
    //public string buttonName = "Fire1";
    public ForceMode forceMode;
    private RaycastHit hit;
    private GameObject[] RedTotal;
    private GameObject[] BlueTotal;
    private GameObject[] GreenTotal;
    private GameObject[] ClassTotal;
    private GameObject[] LevelTotal;
    private bool isStuck = false;
    public GameObject platform;
    //public Texture stuckButton;
    private GamePanels GamePanels;
    private ActiveButtons ActiveButton;
    private SpawnCube SpawnCube;
    private GUIStyle guiStyle = new GUIStyle();

    void Start()
    {
        GamePanels = GetComponent<GamePanels>();
        ActiveButton = GetComponent<ActiveButtons>();
        SpawnCube = GetComponent<SpawnCube>();        
        Vector3 newPos = new Vector3(0, 0, 0);
        initialValues(blueName, redName, greenName, torque, force, 0, 0, 0);
        isStuck = false;
    }

    // Update is called once per frame
    void Update () {
        BlueTotal = GameObject.FindGameObjectsWithTag("BlueDice");
        GreenTotal = GameObject.FindGameObjectsWithTag("GreenDice");
        RedTotal = GameObject.FindGameObjectsWithTag("RedDice");
        ClassTotal = GameObject.FindGameObjectsWithTag("ClassDice");
        LevelTotal = GameObject.FindGameObjectsWithTag("LevelDice");
        
    }


    public void BeforeDiceMovement()
    {

        if ((SpawnCube.getDiceTotal() < 0))
        {
            GamePanels.turnOnRollPanel2();
            Debug.Log("BeforeDiceMovement");
        }
        else
        {
            ActiveButton.ButtonNotActive();
            moveDice();
        }       
        
    }


    /**
     * This method is used to give dice movement(force and torque)
     * **/
    public void moveDice()
    {        
        
        //resetting each color dice total
        resetDiceSums(0, 0, 0, 0, 0);
        Vector3 newPos = new Vector3(9, 17, 0);
        platform.transform.position = newPos;

        try
        {
            Invoke("UpdateDiceMovement", 3f);

            foreach (GameObject Die in (BlueTotal))
            {
                ApplyForce(Die);
            }
            foreach (GameObject Die in (RedTotal))
            {
                ApplyForce(Die);
            }
            foreach (GameObject Die in (GreenTotal))
            {
                ApplyForce(Die);
            }
            foreach (GameObject Die in (ClassTotal))
            {
                ApplyForce(Die);
            }
            foreach (GameObject Die in (LevelTotal))
            {
                ApplyForce(Die);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void ApplyForce(GameObject Die)
    {
        Die.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * getForce(), forceMode);
        Die.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * getTorque(), forceMode);
    }

    /**
     * This method controls when the dice collides and what happens after that point. 
     * Getting proper values to display from each individual dice and calculating the result from each color
     * **/
    private void UpdateDiceMovement()
    {


        Vector3 newPos = new Vector3(9, 15.51f, 0);
        platform.transform.position = newPos;
        //GUI.DrawTexture(new Rect(10, 10, 60, 60), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
        Invoke("updateYellowFont", .3f);
        Invoke("updateRedFont", .6f);
        Invoke("updateYellowFont", .9f);
        Invoke("updateRedFont", 1.0f);
        Invoke("getObjSum", 2f);       
    }



    private void getObjSum()
    {
        ActiveButton.ButtonIsActive();

        foreach (GameObject Red in RedTotal)
        {

            if (Physics.Raycast(Red.transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer))
            {
                setRedValue(hit.collider.GetComponent<DieValue>().value);
                setRedSum(getRedSum() + getRedValue());
            }
            else
            {
                isStuck = true;
            }
        }
        foreach (GameObject Blue in BlueTotal)
        {
            if (Physics.Raycast(Blue.transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer))            {
                setBlueValue(hit.collider.GetComponent<DieValue>().value);
                setBlueSum(getBlueSum() + getBlueValue());
            }
            else
            {
                isStuck = true;
            }
        }
        foreach (GameObject Green in GreenTotal)
        {
            if (Physics.Raycast(Green.transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer))
            {
                setGreenValue(hit.collider.GetComponent<DieValue>().value);
                setGreenSum(getGreenSum() + getGreenValue());
            }
            else
            {
                isStuck = true;
            }
        }

        if(isStuck == true) 
        {
            GamePanels.turnOnRollPanel1();
            isStuck = false;
        }
    }
    
             
}
