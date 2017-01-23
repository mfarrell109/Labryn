using Assets.Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public MonsterGenerator mg = new MonsterGenerator();
	// Use this for initialization
	void Start () {
        mg.GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
