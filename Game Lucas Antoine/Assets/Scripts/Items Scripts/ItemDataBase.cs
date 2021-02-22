using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// As unity does not serialize the dictionaries, callback func OnAfterDes...
[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDataBase : ScriptableObject, ISerializationCallbackReceiver
{
    // Array of all the items in our game
    public ItemObject[] Items;
    //Dictionary to have the item with the id
    public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();
    

    public void OnAfterDeserialize()
    {
        // For each item in the Items array
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].Id = i;
            GetItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObject>();
    }
}
