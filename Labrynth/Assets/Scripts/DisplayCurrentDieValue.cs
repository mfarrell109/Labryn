using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour {

    public LayerMask dieValueColliderLayer = -1;
    public string diColor = "";
    public int currentValue = 1;
    public static float screenPos = 30f;
    RaycastHit hit;

    
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer)) ;
        {
            currentValue = hit.collider.GetComponent<DieValue>().value;
        }

    }

    void OnGUI()
    {
        if (diColor == "Green")
        {        
            GUI.Label(new Rect(10, 10, 100, 20), diColor + ": " + currentValue.ToString());
        }
        else if (diColor == "Red")
        {
         
            GUI.Label(new Rect(10, 30, 100, 20), diColor + ": " + currentValue.ToString());
        }
        else if (diColor == "Yellow")
        {
         
            GUI.Label(new Rect(10, 50, 100, 20), diColor + ": " + currentValue.ToString());
        }
        else if (diColor == "Blue")
        {
            GUI.Label(new Rect(10, 70, 100, 20), diColor + ": " + currentValue.ToString());
        }
        else
        {
            GUI.Label(new Rect(10, 70, 100, 20), "No dice was accepted");
        }


    }
}
