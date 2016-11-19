using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static float TimeCount = 0f;
    private Text timeText;
    public float sec;
    private string timeDisplay;
    public int width = 2;



    // Use this for initialization
    void Start () {

        timeText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        sec += Time.deltaTime;
        timeText.text = sec.ToString("F0");
	
	}

}
