using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Character;

public class OnScreenIcons : MonoBehaviour {
    public Font greekfont;
    private GUIStyle guiStyle = new GUIStyle();
    private DiceMovement DiceMovement;    
    public Texture2D iconDefense;
    public Texture2D iconAttack;
    public Texture2D iconHP;
    public Texture2D iconMovement;
    public Texture2D levelDiceIcon;
    public Texture2D classDiceIcon;
    private SpawnCube SpawnCube;
    //public GameObject monster;
    private MonsterGenerator mg;
    private CharacterBase charBase;

    // Use this for initialization
    void Start () {
        DiceMovement = GetComponent<DiceMovement>();
        charBase = new CharacterBase(CharacterType.Player, 100);
        //monster = GetComponent<GameObject>();
        mg = GetComponent<MonsterGenerator>();
        SpawnCube = GetComponent<SpawnCube>();
        guiStyle.fontSize = 80;
        guiStyle.normal.textColor = Color.white;
        guiStyle.font = greekfont;
    }

    void Update()
    {
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


    //public void getClass()
    //{
    //    Debug.Log(mg.genRandomMonster);
    //}

    void OnGUI()
    {
        /* Player Icons */
        GUI.DrawTexture(new Rect(-13, 0, 110, 75), iconDefense);
        GUI.Label(new Rect(77, 11, 0, 0), DiceMovement.getBlueSum().ToString(), guiStyle);
        GUI.DrawTexture(new Rect(7, 90, 75, 75), iconAttack);
        GUI.Label(new Rect(77, 90, 0, 0),  DiceMovement.getRedSum().ToString(), guiStyle);
        GUI.DrawTexture(new Rect(7, 180, 75, 75), iconMovement);
        GUI.Label(new Rect(77, 180, 105, 105), DiceMovement.getGreenSum().ToString(), guiStyle);
        GUI.DrawTexture(new Rect(7, 265, 70, 70), iconHP);
        GUI.Label(new Rect(77, 265, 105, 105), charBase.getHP.ToString(), guiStyle);
        /* Monster Icons */
        GUI.DrawTexture(new Rect(497, 100, 110, 75), iconDefense);
        GUI.Label(new Rect(585, 110, 105, 105), mg.getDefense.ToString(), guiStyle);
        GUI.DrawTexture(new Rect(515, 180, 75, 75), iconAttack);
        GUI.Label(new Rect(585, 180, 75, 75), mg.getAttack.ToString(), guiStyle);
        GUI.DrawTexture(new Rect(515, 265, 70, 70), iconHP);
        GUI.Label(new Rect(585, 265, 105, 105), mg.getHP.ToString(), guiStyle);


    }

}
