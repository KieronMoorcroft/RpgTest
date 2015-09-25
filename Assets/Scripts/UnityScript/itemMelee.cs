using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class itemMelee : MonoBehaviour {

    public enum MeleeAction
    {
        BuffDebuff,
        ChangeHP,
        ActivateEnv,
        None
    };
    public enum MeleeType
    {
        Armor,
        Potion,
        None
    };

    public int Amount, Value;
    public float Weight;
    public string Name, Stat;
    public MeleeAction meleeAction = MeleeAction.None;
    public MeleeType meleeType = MeleeType.None;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void BuffDebuffStat(GameObject other)
    {
        other.SendMessage("BuffDebuffStat", new KeyValuePair<string, int>(Stat, Amount));
    }

    void ChangeHealth(GameObject other)
    {
        other.SendMessage("ChangeHealth", Amount);
    }

    void ActivateEnviroment(GameObject other)
    {
        other.SendMessage("Activate");
    }

    void OnTriggerEnter(Collider col)
    {
        switch(col.gameObject.tag)
        {
            case "Enemy":
                if(meleeType == MeleeType.Potion)
                {
                    if (meleeAction == MeleeAction.ChangeHP)
                        ChangeHealth(col.gameObject);

                    if (meleeAction == MeleeAction.BuffDebuff)
                        BuffDebuffStat(col.gameObject);

                    if (meleeAction == MeleeAction.ActivateEnv)
                        ActivateEnviroment(col.gameObject);
                }
                break;
            case "Enviroment":
                if(meleeType != MeleeType.Potion)
                {
                    if (meleeAction == MeleeAction.ChangeHP)
                        ChangeHealth(col.gameObject);

                    if (meleeAction == MeleeAction.BuffDebuff)
                        BuffDebuffStat(col.gameObject);
                }
                break;
        }
                if (meleeType == MeleeType.Potion)
                    Destroy(gameObject);

        }
    }
