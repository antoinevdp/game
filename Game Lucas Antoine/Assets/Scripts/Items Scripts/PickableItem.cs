using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickableItem : InteractableBase
{

    public ItemObject item;
    public InventoryObject inventory;
    
    public override void OnInterract()
    {
        base.OnInterract();
        
        inventory.AddItem(item, 1);
        Destroy(gameObject);
    }
}
