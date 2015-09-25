using UnityEngine;
using System.Collections;

public class pickItemUp : MonoBehaviour {

    public Inventory itemType;
    public itemSelf ItemSelf;
    public itemMelee ItemMelee;
    public itemRanged ItemRanged;
    public int itemAmount = 1;
    private bool pickedUp = false;

    void Awake()
    {
        itemAmount = itemType.AddToInventory(itemAmount);
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (GameObject.FindWithTag("Player"))
        {
            if (pickedUp) return;
            itemType.AddToInventory(itemAmount, gameObject);
            pickedUp = true;
        }
                    
    }

   /*  void Reset()
    {
       
        if(collider == null)
        {
            gameObject.AddComponent<SphereCollider>();
        }

        collider.isTrigger = true;
    }*/

}
