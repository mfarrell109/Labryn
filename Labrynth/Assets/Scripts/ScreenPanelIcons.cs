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
    private MonsterGenerator MonsterGenerator = new MonsterGenerator();

    // Use this for initialization
    void Start () {

 
        MonsterGenerator = GetComponent<MonsterGenerator>();
        //MonsterGenerator.BuildMonsterList();
        

        //MonsterGenerator.MonsterList.ToString();

        guiStyle.fontSize = 48;
        guiStyle.normal.textColor = Color.white;
        guiStyle.font = greekfont;        

    }	

    //public string jsonPrint()
    //{
    //    string json;
    //    //string[] result;
    //    using (StreamReader sr = new StreamReader(Path.GetFullPath(@"Assets\Scripts\MonsterRollSheet.json")))
    //    {
    //        json = sr.ReadToEnd();
    //    }

    //    MonsterStats[] st = MonsterGenerator.getJsonArray<MonsterStats>(json);
    //    return st.ToString();
    //}

    void OnGUI()
    {
        //Player Panel
        GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement + 50, 0, 0), "Attack Mod:   " , guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement + 100, 0, 0), "Movement Mod: ", guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement + 150, 0, 0), "Defense Mode: ", guiStyle);
        //Monster Panel
        GUI.Label(new Rect(ScreenWidthPlacement + 510, ScreenHeightPlacement + 50, 0, 0),  "Class:  " , guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement + 510, ScreenHeightPlacement + 100, 0, 0), "Level:  ", guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement + 510, ScreenHeightPlacement + 150, 0, 0), "Reward: ", guiStyle);
        GUI.Label(new Rect(ScreenWidthPlacement + 510, ScreenHeightPlacement + 150, 0, 0), "Reward: ", guiStyle);
        //GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement + 300, 0, 0), "Attack Mod:   " + MonsterGenerator.BuildMonsterList(), guiStyle);
    }
}
