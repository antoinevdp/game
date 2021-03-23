using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    #region Variables
    
        //savePaths
        public string savePath;

        // Inventory
        public Inventory Container;

        //Database
        public ItemDataBase itemDataBase;
        

        #endregion

    #region Custom Methods

        public void AddItem(Item _item, int _amount)
        {
            // Loop for all the inventory slots to check
            for (int i = 0; i < Container.Items.Count; i++)
            {
                // If the item of the current slot equals the item we want to add:
                if (Container.Items[i].item.Id == _item.Id)
                {
                    //we add the amount in the actual slot
                    Container.Items[i].AddAmount(_amount);
                    return;
                }
            }
            //if item is not in inventory
            //We create a new slot with the item and amount specified
            // And the id is get from the database
            Container.Items.Add(new InventorySlot(_item.Id,_item, _amount));
        }

        [ContextMenu("Save")]
        public void Save()
        {
            //string saveData = JsonUtility.ToJson(this, true);
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
            //bf.Serialize(file, saveData);
            //file.Close();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create,
                FileAccess.Write);
            formatter.Serialize(stream, Container);
            stream.Close();
        }
        
        [ContextMenu("Load")]
        public void Load()
        {
            if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
            {
                //BinaryFormatter bf = new BinaryFormatter();
                //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
                //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
                //file.Close();
                
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open,
                    FileAccess.Read);
                Container = (Inventory) formatter.Deserialize(stream);
                stream.Close();
            }
        }

        [ContextMenu("Clear")]
        public void Clear()
        {
            Container = new Inventory();
        }

    #endregion

}

[System.Serializable]
public class Inventory
{
    //Store InventorySlot class objects
    public List<InventorySlot> Items = new List<InventorySlot>();
}

[System.Serializable]
public class InventorySlot
{
    //Store The actual item and amount of a slot and id
    public int ID;
    public Item item;
    public int amount;

    public InventorySlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}