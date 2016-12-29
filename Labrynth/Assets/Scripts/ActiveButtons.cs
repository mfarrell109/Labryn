using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActiveButtons : MonoBehaviour {

    public GameObject rollButton;
    private ActiveButtons ActiveButton;
	// Use this for initialization
	void Start () {
        rollButton.GetComponent<GameObject>();
        rollButton.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonNotActive()
    {
        rollButton.SetActive(false);
    }

    public void ButtonIsActive()
    {
        rollButton.SetActive(true);
    }
}
