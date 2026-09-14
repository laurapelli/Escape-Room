using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem current;

    [SerializeField]
    private InventoryBarController inventoryBar;

    private Dictionary<InventoryItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> inventory { get; private set;}

    public int inventorySlots = 4;

    private void Awake(){
        if (current != null){
            return;
        }
        inventory = new List<InventoryItem>();
        itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();

        current = this;
    }

    public InventoryItem Get(InventoryItemData referenceData){
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value)){
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData referenceData){
        if (GetNumberOfOccupiedSlots() >= inventorySlots){
            return;
        }

        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value)){
            value.AddToStack();
        } else {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            itemDictionary.Add(referenceData, newItem);
        }
        inventoryBar.OnUpdateInventory();
    }

    public void Remove(InventoryItemData referenceData){
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value)){
            value.RemoveFromStack();

            if (value.stackSize == 0){
                inventory.Remove(value);
                itemDictionary.Remove(referenceData);
            }
        }
        inventoryBar.OnUpdateInventory();
    }

    public bool HasFreeSpots(){
        return GetNumberOfOccupiedSlots() < inventorySlots;
    }

    private int GetNumberOfOccupiedSlots(){
        int occupiedSlots = 0;
        foreach (InventoryItem item in inventory){
            occupiedSlots += item.stackSize;
        }
        return occupiedSlots;
    }
}
