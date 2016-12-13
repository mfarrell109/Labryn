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
    public Font greekfont;
    RaycastHit hit;
    private GUIStyle guiStyle = new GUIStyle();
    private GameObject[] RedTotal;
    private GameObject[] BlueTotal;
<<<<<<< HEAD
    private GameObject[] GreenTotal;
=======
    private GameObject[] GreenTotal;
    private GameObject[] ClassTotal;
    private GameObject[] LevelTotal;
    private bool redStop = false;
>>>>>>> f8accb9065c968fe0c9fc5957770ae629d4b969a
    BaseDieModel DisplayDie = new BaseDieModel();
    
    void Start ()
    {

        BlueTotal = GameObject.FindGameObjectsWithTag("BlueDice");
        GreenTotal = GameObject.FindGameObjectsWithTag("GreenDice");
        RedTotal = GameObject.FindGameObjectsWithTag("RedDice");
<<<<<<< HEAD

        guiStyle.fontSize = 32;
        guiStyle.normal.textColor = Color.red;
        guiStyle.font = greekfont;
=======
        ClassTotal = GameObject.FindGameObjectsWithTag("ClassDice");
        LevelTotal = GameObject.FindGameObjectsWithTag("LevelDice");
>>>>>>> f8accb9065c968fe0c9fc5957770ae629d4b969a
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
        ClassTotal = GameObject.FindGameObjectsWithTag("ClassDice");
        LevelTotal = GameObject.FindGameObjectsWithTag("LevelDice");

        //resetting each color dice total
<<<<<<< HEAD
        resetDiceSums();
=======
        DisplayDie.setRedSum(0);
        DisplayDie.setBlueSum(0);
        DisplayDie.setGreenSum(0);
        DisplayDie.SetClassSum(0);
        DisplayDie.SetLevelSum(0);
>>>>>>> f8accb9065c968fe0c9fc5957770ae629d4b969a

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
<<<<<<< HEAD

        
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

=======
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
>>>>>>> f8accb9065c968fe0c9fc5957770ae629d4b969a
    
    /**
     * Labels to display for dice roll. Getting calculated values using the BaseDieModel
     **/
    void OnGUI()
    {
<<<<<<< HEAD
        //GUILayout.Label(new Rect(10, 10, 100, 20), DisplayDie.getBlueDiceName() + ": " + DisplayDie.getBlueSum());
        //GUI.contentColor = Color.black;
        //GUI.DrawTexture(new Rect(100, 10, 100, 20), atexture, ScaleMode.ScaleToFit, true, 10.0F);
        GUI.Label(new Rect(10, 10, 100, 20) , DisplayDie.getBlueDiceName() +  ": " + DisplayDie.getBlueSum(), guiStyle);
        GUI.Label(new Rect(10, 40, 100, 20), DisplayDie.getRedDiceName() + ": " + DisplayDie.getRedSum(),guiStyle);
        GUI.Label(new Rect(10, 70, 100, 20), DisplayDie.getGreenName() + ": "  + DisplayDie.getGreenSum(), guiStyle);
=======
        GUI.Label(new Rect(10, 10, 100, 20), DisplayDie.getBlueDiceName() +  ": " + DisplayDie.getBlueSum());
        GUI.Label(new Rect(0, 30, 100, 20), DisplayDie.getRedDiceName() + ": " + DisplayDie.getRedSum());
        GUI.Label(new Rect(10, 50, 100, 20), DisplayDie.getGreenName() + ": "  + DisplayDie.getGreenSum());
        GUI.Label(new Rect(10, 70, 100, 20), DisplayDie.GetClassName() + ": " + DisplayDie.GetClassValue());
        GUI.Label(new Rect(10, 90, 100, 20), DisplayDie.GetLevelName() + ": " + DisplayDie.GetLevelValue());
>>>>>>> f8accb9065c968fe0c9fc5957770ae629d4b969a
    }

}
