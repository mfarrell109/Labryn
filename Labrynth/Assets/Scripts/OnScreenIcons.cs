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
    public SpawnCube SpawnCube;
    // Use this for initialization
    void Start () {
        DiceMovement = GetComponent<DiceMovement>();
        SpawnCube = GetComponent<SpawnCube>();
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
        //Dice Icons
        GUI.DrawTexture(new Rect(7, 0, 115, 115), iconDefense);
        GUI.Label(new Rect(110, 0, 0, 0), DiceMovement.getBlueSum().ToString(), guiStyle);
        GUI.DrawTexture(new Rect(15, 110, 100, 100), iconAttack);
        GUI.Label(new Rect(110, 110, 0, 0),  DiceMovement.getRedSum().ToString(), guiStyle);
        GUI.DrawTexture(new Rect(15, 220, 100, 100), iconMovement);
        GUI.Label(new Rect(110, 220, 105, 105), DiceMovement.getGreenSum().ToString(), guiStyle);
        //GUI.Label(new Rect(ScreenWidthPlacement, ScreenHeightPlacement, 0, 0), "HP: ", guiStyle);
        //Player Panel

        //Monster Panel
        //GUI.Label(new Rect(100, 280, 105, 105), "Dice Amount: " + SpawnCube.getDiceTotal().ToString() , guiStyle);
        //GUI.Label(new Rect(35, 130, 100, 20), DiceMovement.GetClassName() + ": " + DiceMovement.GetClassValue(), guiStyle);
        //GUI.Label(new Rect(35, 170, 100, 20), GetLevelName() + ": " + GetLevelValue(), guiStyle);

    }

}
