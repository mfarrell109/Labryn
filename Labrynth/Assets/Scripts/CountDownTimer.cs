using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {

    public static float startTime = 30f;
    private float sec;
    private Text timeText;

	// Use this for initialization
	void Start () {

        timeText = GetComponent<Text>(); 
	    
	}
	
	// Update is called once per frame
	void Update () {
        startTime -= Time.deltaTime;
        timeText.text = startTime.ToString("F0");

	}
}
