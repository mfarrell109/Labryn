using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject RedCube;
    public GameObject GreenCube;
    public GameObject BlueCube;
    public GameObject ClassCube;
    public GameObject LevelCube;

    public int MaxRedCube = 1;
    public int MaxBlueCube = 1;
    public int MaxGreenCube = 1;

    int redloc = 5;
    int greenloc = 10;
    int blueloc = 15;
    int redTotal = 0;
    int blueTotal = 0;
    int greenTotal = 0;
    // Use this for initialization
    void Start()
    {
        RedCube.GetComponent<Rigidbody>();
        BlueCube.GetComponent<Rigidbody>();
        GreenCube.GetComponent<Rigidbody>();
        ClassCube.GetComponent<Rigidbody>();
        LevelCube.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnRed()
    {
        if (redTotal++ < MaxRedCube)
            Instantiate(RedCube, new Vector3(redloc, 5, 0), transform.rotation);
    }

    public void spawnGreen()
    {
        if (greenTotal++ < MaxGreenCube)
            Instantiate(GreenCube, new Vector3(greenloc, 5, 0), transform.rotation);
    }

    public void spawnBlue()
    {
        if (blueTotal++ < MaxBlueCube)
            Instantiate(BlueCube, new Vector3(blueloc, 5, 0), transform.rotation);
    }
    public void spawnMonsterDice()
    {
        Instantiate(ClassCube, new Vector3(blueloc, 5, 0), transform.rotation);
        Instantiate(LevelCube, new Vector3(redloc, 5, 0), transform.rotation);
    }
}
