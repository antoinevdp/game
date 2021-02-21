using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    //Store InventorySlot class objects
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddItem(ItemObject _item, int _amount)
    {
        // bool to check if the item we want to add is in the inv
        bool isItemInInventory = false;
        // Loop for all the inventory slots to check
        for (int i = 0; i < Container.Count; i++)
        {
            // If the item of the current slot equals the item we want to add:
            if (Container[i].item == _item)
            {
                //we add the amount in the actual slot
                Container[i].AddAmount(_amount);
                //Item is in the inventory
                isItemInInventory = true;
                // As item slot was found, we dont want to continue looping
                break;
            }
        }
        //if item is not in inventory
        if (!isItemInInventory)
        {
            //We create a new slot with the item and amount specified
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    //Store The actual item and amount of a slot
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}