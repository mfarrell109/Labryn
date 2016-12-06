using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour {

    public GameObject RedCube;
    public GameObject GreenCube;
    public GameObject BlueCube;
    int redloc = 5;
    int greenloc = 10;
    int blueloc = 15;
	// Use this for initialization
	void Start () {
        RedCube.GetComponent<Rigidbody>();
        BlueCube.GetComponent<Rigidbody>();
        GreenCube.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnRed()
    {
        Instantiate(RedCube, new Vector3(redloc, 5, 0), transform.rotation);        
    }

    public void spawnGreen()
    {
        Instantiate(GreenCube, new Vector3(greenloc, 5, 0), transform.rotation);
    }

    public void spawnBlue()
    {
        Instantiate(BlueCube, new Vector3(blueloc, 5, 0), transform.rotation);
    }
}
