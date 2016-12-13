// Instantiates respawnPrefab at the location 
// of all game objects tagged "Respawn".

using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject respawnPrefab;
    GameObject[] respawns;
    private float greenloc;
    private int diceAmount;
    private int maxNumDice;
    private int minNumDice;

    void Start()
    {

            //respawns = GameObject.FindGameObjectsWithTag("RedDice");        
    }

    private void Update()
    {
       respawns = GameObject.FindGameObjectsWithTag("RedDice");
       diceAmount = respawns.Length - 1;
       maxNumDice = 2;
       minNumDice = -1;
    }

    public void spawnDi()
    {
        if (diceAmount < maxNumDice)
        {
            Instantiate(respawnPrefab, new Vector3(5, 5, 0), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            Debug.Log("You have the max amount of dice already. Please make another selection");
        }        
    }

    public void DestroyDi()
    {
        if (diceAmount > minNumDice)
        {
            Destroy(respawns[respawns.Length - 1]);
        }
        else
        {
            Debug.Log("You have 0 dice already. Please make a selection");
        }
    }
}