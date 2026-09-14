using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionController : MonoBehaviour
{

    public InventorySystem inventory;


    private void OnTriggerEnter2D(Collider2D other) {
        // check if collided object is an item
        ItemDataContainer item = other.gameObject.GetComponent<ItemDataContainer>();
        if (item != null){
            InventoryItemData foundItem = item.inventoryItemData;
            
            if (inventory.HasFreeSpots()){
                // add to items
                inventory.Add(foundItem);

                // remove item from map
                Destroy(other.gameObject);
            }
        }
    }
}
