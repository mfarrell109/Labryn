using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenIcons : MonoBehaviour {
    public Font greekfont;
    private GUIStyle guiStyle = new GUIStyle();
    private DiceMovement DiceMovement;
    public Texture2D iconDefense;
    public Texture2D iconAttack;
    public Texture2D iconMovement;
    // Use this for initialization
    void Start () {
        DiceMovement = GetComponent<DiceMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        guiStyle.fontSize = 108;
        guiStyle.normal.textColor = Color.white;
        guiStyle.font = greekfont;
    }

    private void updateYellowFont()
    {
        guiStyle.normal.textColor = Color.yellow;
        Debug.Log("Yellow Count: ");
    }

    private void updateRedFont()
    {
        guiStyle.normal.textColor = Color.red;
        Debug.Log("Red Count: ");
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, 105, 105), iconDefense);
        GUI.Label(new Rect(100, 0, 0, 0), DiceMovement.getBlueSum().ToString(), guiStyle);
        GUI.DrawTexture(new Rect(0, 110, 105, 105), iconAttack);
        GUI.Label(new Rect(100, 110, 0, 0),  DiceMovement.getRedSum().ToString(), guiStyle);
        GUI.DrawTexture(new Rect(0, 220, 105, 105), iconMovement);
        GUI.Label(new Rect(100, 220, 105, 105), DiceMovement.getGreenSum().ToString(), guiStyle);
        //GUI.Label(new Rect(35, 130, 100, 20), DiceMovement.GetClassName() + ": " + DiceMovement.GetClassValue(), guiStyle);
        //GUI.Label(new Rect(35, 170, 100, 20), GetLevelName() + ": " + GetLevelValue(), guiStyle);

    }

}
