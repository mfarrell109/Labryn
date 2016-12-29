using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPanelIcons : MonoBehaviour {

    public Font greekfont;
    public int ScreenWidthPlacement;
    public int ScreenHeightPlacement;
    private GUIStyle guiStyle = new GUIStyle();
    // Use this for initialization
    void Start () {
        guiStyle.fontSize = 48;
        guiStyle.normal.textColor = Color.white;
        guiStyle.font = greekfont;
    }	


    void OnGUI()
    {        
        //Player Panel
        GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement + 50, 0, 0), "Attack Mod:   ", guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement + 100, 0, 0), "Movement Mod: ", guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement + 150, 0, 0), "Defense Mode: ", guiStyle);
        //Monster Panel
        GUI.Label(new Rect(ScreenWidthPlacement + 510, ScreenHeightPlacement + 50, 0, 0),  "Class:  ", guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement + 510, ScreenHeightPlacement + 100, 0, 0), "Level:  ", guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement + 510, ScreenHeightPlacement + 150, 0, 0), "Reward: ", guiStyle);
    }
}
