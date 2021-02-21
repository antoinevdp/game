using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : ScriptableObject
{
    //Store InventorySlot objects
    public List<InventorySlot> Container = new List<InventorySlot>();
}

[System.Serializable]
public class InventorySlot
{
    //Store The actual item aand amount on a slot
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void Addamount(int value)
    {
        amount += value;
    }
}