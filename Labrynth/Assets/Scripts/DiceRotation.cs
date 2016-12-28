using UnityEngine;
using System.Collections;
using System;
using System.Linq;

/*
 * This script was created to apply attributes regarding physics to dice 
 */
public class DiceRotation : BaseDIeModel
{


    public LayerMask dieValueColliderLayer = -1;
    //public string buttonName = "Fire1";
    public ForceMode forceMode;
    public Font greekfont;
    RaycastHit hit;
    private GUIStyle guiStyle = new GUIStyle();
    private GameObject[] RedTotal;
    private GameObject[] BlueTotal;
    private GameObject[] GreenTotal;
    private GameObject[] ClassTotal;
    private GameObject[] LevelTotal;
    public GameObject platform;
    private Vector3 newPos;

    void Start()
    {
        platform.GetComponent<GameObject>();
        Vector3 newPos = new Vector3(0, 0, 0);
        initialValues(blueName, redName, greenName, torque, force, 0, 0, 0);

        guiStyle.fontSize = 48;
        guiStyle.normal.textColor = Color.red;
        guiStyle.font = greekfont;
    }

    // Update is called once per frame
    void Update()
    {
        //platform.AddComponent<Rigidbody>();
        platform.GetComponent<GameObject>();
        BlueTotal = GameObject.FindGameObjectsWithTag("BlueDice");
        GreenTotal = GameObject.FindGameObjectsWithTag("GreenDice");
        RedTotal = GameObject.FindGameObjectsWithTag("RedDice");
        ClassTotal = GameObject.FindGameObjectsWithTag("ClassDice");
        LevelTotal = GameObject.FindGameObjectsWithTag("LevelDice");
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
        Vector3 newPos = new Vector3(9, 15.37f, 0);
        platform.transform.position = newPos;
        
        //GUI.DrawTexture(new Rect(10, 10, 60, 60), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
        Invoke("updateYellowFont", .3f);
        Invoke("updateRedFont", .6f);
        Invoke("updateYellowFont", .9f);
        Invoke("updateRedFont", 2f);
        
        foreach (GameObject Red in RedTotal)
        {

            if (Physics.Raycast(Red.transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer) &&
                (Red.GetComponent<Rigidbody>().velocity == Vector3.zero) &&
                (Red.GetComponent<Rigidbody>().angularVelocity == Vector3.zero))
            {
                setRedValue(hit.collider.GetComponent<DieValue>().value);
                setRedSum(getRedSum() + getRedValue());

            }
        }
        foreach (GameObject Blue in BlueTotal)
        {
            if (Physics.Raycast(Blue.transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer) &&
                (Blue.GetComponent<Rigidbody>().velocity == Vector3.zero) &&
                (Blue.GetComponent<Rigidbody>().angularVelocity == Vector3.zero))
            {
                setBlueValue(hit.collider.GetComponent<DieValue>().value);
                setBlueSum(getBlueSum() + getBlueValue());
            }
        }
        foreach (GameObject Green in GreenTotal)
        {
            if (Physics.Raycast(Green.transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer) &&
                (Green.GetComponent<Rigidbody>().velocity == Vector3.zero) &&
                (Green.GetComponent<Rigidbody>().angularVelocity == Vector3.zero))
            {
                setGreenValue(hit.collider.GetComponent<DieValue>().value);
                setGreenSum(getGreenSum() + getGreenValue());
            }
        }
    }

    private void updateYellowFont()
    {
        guiStyle.normal.textColor = Color.yellow;
        Debug.Log("Yellow Count: ");
    }

    private void updateRedFont()
    {
        guiStyle.normal.textColor = Color.red;
        Debug.Log("Red Count: ");
    }

    /**
     * Labels to display for dice roll. Getting calculated values using the BaseDieModel
     **/
    void OnGUI()
    {
        GUI.Label(new Rect(35, 10, 100, 20), getBlueDiceName() + ": " + getBlueSum(), guiStyle);

        GUI.Label(new Rect(35, 50, 100, 20), getRedDiceName() + ": " + getRedSum(), guiStyle);
        GUI.Label(new Rect(35, 90, 100, 20), getGreenName() + ": " + getGreenSum(), guiStyle);
        GUI.Label(new Rect(35, 130, 100, 20), GetClassName() + ": " + GetClassValue(), guiStyle);
        GUI.Label(new Rect(35, 170, 100, 20), GetLevelName() + ": " + GetLevelValue(), guiStyle);
    }

}
