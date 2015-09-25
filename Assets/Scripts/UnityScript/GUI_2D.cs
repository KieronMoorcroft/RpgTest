using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GUI_2D : MonoBehaviour {

    // List for skills and items
    List<Rect> SkillButtons = new List<Rect>();
    List<Rect> ItemButtons = new List<Rect>();

    //Health variables
    public float currentHP = 100;
    public float maxHP = 100;
    public float currentBarLength;
    public float maxBarLength = 100;

    //Level variables
    public int currentLevel = 1;
    public GUIStyle myStyle;

    //The experience variables
    public float maxExperience = 100;
    public float currentExperience = 0;
    public float currentExpBarLength;
    public float maxExpBarLength = 100;
	// Use this for initialization
	void Start () 
    {

        SkillButtons.Add(new Rect(Screen.width/ 2 + 50, Screen.height /3 + 333, 55, 55));
        SkillButtons.Add(new Rect(Screen.width/ 2 + 105, Screen.height /3 + 333, 55, 55));
        SkillButtons.Add(new Rect(Screen.width/ 2 + 160, Screen.height /3 + 333, 55, 55));

        ItemButtons.Add(new Rect(Screen.width/ 2 - 160, Screen.height /3 + 333, 55, 55));
        ItemButtons.Add(new Rect(Screen.width/ 2 - 105, Screen.height /3 + 333, 55, 55));
        ItemButtons.Add(new Rect(Screen.width/ 2 - 50, Screen.height /3 + 333, 55, 55));

        // myStyle level counter fontsize
        myStyle.fontSize = 36;

	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
    
    void OnGUI()
    {

        GUI.Button(SkillButtons[0], "Skill A");
        GUI.Button(SkillButtons[1], "Skill B");
        GUI.Button(SkillButtons[2], "Skill C");
        GUI.Button(ItemButtons[0], "Item A");
        GUI.Button(ItemButtons[1], "Item B");
        GUI.Button(ItemButtons[2], "Item C");

        //The health GUI
        currentBarLength = currentHP * maxBarLength / maxHP;
        GUI.Box(new Rect(Screen.width/ 2 - 20, Screen.height/ 2 + 300, currentBarLength, 25f), "");

        //The level GUI
        GUI.Label(new Rect(Screen.width/ 2 + 15, Screen.height/ 2 + 335, 30, 30), currentLevel.ToString(), myStyle);

        //Experience GUI
        currentExpBarLength = currentExperience * maxExpBarLength/ maxExperience;
        if(currentExpBarLength > 5)
        {
            GUI.Box(new Rect(Screen.width/ 2 - 20, Screen.height/ 2 - 300, currentExpBarLength, 25), "");
            GUI.Box(new Rect(Screen.width/ 2 - 20, Screen.height/ 2 - 300, maxExperience, 25), "");
        }
        if(currentExpBarLength >= maxExpBarLength)
        {
            currentExpBarLength = 0;
            currentExperience = 0;
            currentLevel++;
        }
    }
}
