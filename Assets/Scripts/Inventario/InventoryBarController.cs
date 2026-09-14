using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBarController : MonoBehaviour
{

    [SerializeField]
    private GameObject itemSlotPrefab;


    public void OnUpdateInventory(){
        foreach(Transform t in transform){
            Destroy(t.gameObject);
        }

        DrawInventory();
    }

    private void DrawInventory(){
        foreach(InventoryItem item in InventorySystem.current.inventory){
            AddInventorySlot(item);
        }
    }

    private void AddInventorySlot(InventoryItem item){
        GameObject obj = Instantiate(itemSlotPrefab);
        obj.transform.SetParent(transform, false);

        ItemSlotController slotController = obj.GetComponent<ItemSlotController>();
        slotController.Set(item);
    }

}
