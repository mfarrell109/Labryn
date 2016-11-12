using UnityEngine;
using System.Collections;

/*
 * This script was created to apply attributes regarding physics to dice 
 */
public class DiceMovement : MonoBehaviour {

    public string buttonName = "Fire1";
    public float force = 10.0f;
    public ForceMode forceMode;
    public float torque = 10.0f;
    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown(buttonName))
        {
            //moveDice();
        }
    }

    public void moveDice()
    {
        rb.AddForce(Random.onUnitSphere * force, forceMode);
        rb.AddTorque(Random.onUnitSphere * torque, forceMode);     
    }
}
