using UnityEngine;
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
    RaycastHit hit;

    private GameObject[] RedTotal;
    private GameObject[] BlueTotal;
    private GameObject[] GreenTotal;
    private GameObject[] ClassTotal;
    private GameObject[] LevelTotal;
    private bool redStop = false;
    BaseDieModel DisplayDie = new BaseDieModel();
    
    void Start ()
    {       
        BlueTotal = GameObject.FindGameObjectsWithTag("BlueDice");
        GreenTotal = GameObject.FindGameObjectsWithTag("GreenDice");
        RedTotal = GameObject.FindGameObjectsWithTag("RedDice");
        ClassTotal = GameObject.FindGameObjectsWithTag("ClassDice");
        LevelTotal = GameObject.FindGameObjectsWithTag("LevelDice");
    }
	
	// Update is called once per frame
	void Update () {
        if(redStop == true)
        {

        }
    }

    /**
     * This method is used to give dice movement(force and torque)
     * **/
    public void moveDice()
    {
        BlueTotal = GameObject.FindGameObjectsWithTag("BlueDice");
        GreenTotal = GameObject.FindGameObjectsWithTag("GreenDice");
        RedTotal = GameObject.FindGameObjectsWithTag("RedDice");
        ClassTotal = GameObject.FindGameObjectsWithTag("ClassDice");
        LevelTotal = GameObject.FindGameObjectsWithTag("LevelDice");

        //resetting each color dice total
        DisplayDie.setRedSum(0);
        DisplayDie.setBlueSum(0);
        DisplayDie.setGreenSum(0);
        DisplayDie.SetClassSum(0);
        DisplayDie.SetLevelSum(0);

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
        Die.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * DisplayDie.getForce(), forceMode);
        Die.GetComponent<Rigidbody>().AddForce(UnityEngine.Random.onUnitSphere * DisplayDie.getTorque(), forceMode);
    }

    /**
     * This method controls when the dice collides and what happens after that point. 
     * Getting proper values to display from each individual dice and calculating the result from each color
     * **/
    private void UpdateDiceMovement()
    {
        foreach (GameObject Red in RedTotal)
        {
            redStop = true;
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
        foreach (GameObject Class in ClassTotal)
        {
            if (Physics.Raycast(Class.transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer) &&
                (Class.GetComponent<Rigidbody>().velocity == Vector3.zero) &&
                (Class.GetComponent<Rigidbody>().angularVelocity == Vector3.zero))
            {
                DisplayDie.SetClassValue(hit.collider.GetComponent<DieValue>().value);
                DisplayDie.SetClassSum(DisplayDie.GetClassSum() + DisplayDie.GetClassValue());
            }
        }
        foreach (GameObject Level in LevelTotal)
        {
            if (Physics.Raycast(Level.transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer) &&
                (Level.GetComponent<Rigidbody>().velocity == Vector3.zero) &&
                (Level.GetComponent<Rigidbody>().angularVelocity == Vector3.zero))
            {
                DisplayDie.SetLevelValue(hit.collider.GetComponent<DieValue>().value);
                DisplayDie.SetLevelSum(DisplayDie.GetLevelSum() + DisplayDie.GetLevelValue());
            }
        }
    }        
    
    /**
     * Labels to display for dice roll. Getting calculated values using the BaseDieModel
     **/
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), DisplayDie.getBlueDiceName() +  ": " + DisplayDie.getBlueSum());
        GUI.Label(new Rect(0, 30, 100, 20), DisplayDie.getRedDiceName() + ": " + DisplayDie.getRedSum());
        GUI.Label(new Rect(10, 50, 100, 20), DisplayDie.getGreenName() + ": "  + DisplayDie.getGreenSum());
        GUI.Label(new Rect(10, 70, 100, 20), DisplayDie.GetClassName() + ": " + DisplayDie.GetClassValue());
        GUI.Label(new Rect(10, 90, 100, 20), DisplayDie.GetLevelName() + ": " + DisplayDie.GetLevelValue());
    }

}
