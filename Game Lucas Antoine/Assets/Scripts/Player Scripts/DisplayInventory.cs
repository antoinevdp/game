using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    // This class is used to display / update the inventory

    #region Variables
    
    // Hold inventory to display
    public InventoryObject inventory;
    
    //Start position in inv
    public int X_START;
    public int Y_START;

    // spaces btwn the item
    public int X_SPACE_BTWN_ITEM;
    public int Y_SPACE_BTWN_ITEM;
    public int NUMBER_OF_COLUMN;
    
    // Item display
    private Dictionary<InventorySlot, GameObject> itemDisplayed = new Dictionary<InventorySlot, GameObject>();

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        // Create the display
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        // Update display
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            // Instantiate the prefab of the item with transform of parent
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            // get text mesh pro in child and set text to the amount of the current number of item
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            // Then, need to add the item to the dictionnary:
            itemDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            // If the item slot exists
            if (itemDisplayed.ContainsKey(inventory.Container[i]))
            {
                // Then, we take the txtMeshPro component in children of that slot and change its text value to the amount 
                itemDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString();
            }
            else
            {
                // If not in inv -> Create obj:
                // Instantiate the prefab of the item with transform of parent
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                // get text mesh pro in child and set text to the amount of the current number of item
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                // Then, need to add the item to the dictionnary:
                itemDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    // Used to get the position of item in inv
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BTWN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BTWN_ITEM * (i/NUMBER_OF_COLUMN)), 0f);
    }
}
