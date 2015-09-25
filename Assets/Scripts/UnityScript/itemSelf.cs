using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class itemSelf : MonoBehaviour {


    public enum SelfAction
    {
        BuffDebuff,
        ChangeHP,
        ChangeArmor,
        None
    };
    public enum SelfType
    {
        Armor,
        Potion,
        None
    };

    public GameObject Player;
    public int Amount, Value, ArmourAmount;
    public float Weight;
    public string Name, Stat;
    public SelfAction selfAction = SelfAction.None;
    public SelfType selfType = SelfType.None;


	// Use this for initialization
	void Start () {

       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void BuffDebuffStat()
    {
        Player.SendMessage("BuffDebuffStat", new KeyValuePair<string, int>(Stat, Amount));
    }

    void ChangeHealth()
    {
        Player.SendMessage("ChangeArmourAmount", Amount);
    }

    void ChangeArmorAmount()
    {
        Player.SendMessage("ChangeArmorAmount", ArmourAmount);
    }

    void Activate()
    {
        switch(selfAction)
        {
            case SelfAction.BuffDebuff:
                BuffDebuffStat();
                break;
            case SelfAction.ChangeHP:
                ChangeHealth();
                break;
            case SelfAction.ChangeArmor:
                ChangeArmorAmount();
                break;
        }
        if ( selfType == SelfType.Potion)
        {
            Destroy(gameObject);
        }
    }
}
