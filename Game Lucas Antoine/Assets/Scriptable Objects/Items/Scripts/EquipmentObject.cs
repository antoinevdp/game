using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public float speedMovementMultiplier;
    public float attackMultiplier;
    public float protectionValue;
    public float radiationProtectionValue;
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
