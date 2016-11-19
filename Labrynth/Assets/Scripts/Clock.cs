using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour {

    private Text textClock;
    private int width = 0;
    private char padding = '0';

	// Use this for initialization
	void Start () {
        textClock = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        DateTime time = DateTime.Now;
        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);

        textClock.text = hour + ":" + minute + ":" + second;

	}

    private string LeadingZero(int n)
    {
        return n.ToString().PadLeft(width, '0');
    }
}
