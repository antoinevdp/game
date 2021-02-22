using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region Variables

    //Give the player an inventory
    public InventoryObject inventory;

    #endregion


    // Check if colliding with something
    private void OnTriggerEnter(Collider other)
    {
        // check if the object we collide with has an Item script:
        var item = other.GetComponent<Item>();
        //If it does have -> means its an object we want to add in inventory:
        if (item)
        {
            // We add to the player inv this item with amount 1
            inventory.AddItem(item.item, 1);
            // As we took the item, it needs to be destroy from scene bc we dont want to have infinite
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
