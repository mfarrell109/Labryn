using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using Assets.Scripts.Character;

public class ScreenPanelIcons : MonoBehaviour {

    public Font greekfont;
    public int ScreenWidthPlacement;
    public int ScreenHeightPlacement;
    private GUIStyle guiStyle = new GUIStyle();
    private MonsterGenerator mg;

    // Use this for initialization
    void Start () {
        mg = GetComponent<MonsterGenerator>();
        guiStyle.fontSize = 48;
        guiStyle.normal.textColor = Color.white;
        guiStyle.font = greekfont;        

    }	

    void OnGUI()
    {
        //Player Panel
        GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement + 50, 0, 0), "Attack Mod:   " , guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement + 100, 0, 0), "Movement Mod: ", guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement + 150, 0, 0), "Defense Mod: " , guiStyle);

        //Monster Panel
        GUI.Label(new Rect(ScreenWidthPlacement + 510, ScreenHeightPlacement + 50, 0, 0),  "Class:  " + mg.getClass.ToString() , guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement + 510, ScreenHeightPlacement + 100, 0, 0), "Level:  " +  mg.getLevel.ToString(), guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement + 510, ScreenHeightPlacement + 150, 0, 0), "Surprise: " + mg.getSurprise , guiStyle);
        //GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement + 300, 0, 0), "Attack Mod:   " + MonsterGenerator.BuildMonsterList(), guiStyle);
    }
}
