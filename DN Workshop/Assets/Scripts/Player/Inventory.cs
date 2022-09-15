using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory instance;
        
        public List<PlayerInventory> itemsInventory;
        public List<InventorySlot> inventorySlots;
        public List<Items_Bag> bags;
        public int bagSlotsCount;
        public int bagsMaxCount;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

            if (bags.Count < bagsMaxCount)
            {
                for (int i = 0; i < bagsMaxCount; i++)
                {
                    bags.Add(null);
                }
            }

            foreach (var b in bags)
            {
                bagSlotsCount += b.slots;
            }
        }

        public void AddToInventory(Items item, int number)
        {
            var newItem = new PlayerInventory()
            {
                item = item,
                count = number
            }; 
            
            itemsInventory.Add(newItem);
        }
    }

    public class UIInventoryInterface : MonoBehaviour
    {
        public void UpdateSlots(Inventory inventory, int maxLines, int maxColumns, Image sPrefab, Transform parent, float spaceSlot, Transform anchoredPos)
        {
            int x = 0;
            int y = 0;
            
            for (int i = 0; i < inventory.bagSlotsCount; i++)
            {
                if (x >= maxColumns)
                {
                    x = 0; 
                    y++; 
                    Debug.Log("YOOO");
                }

                var slotPos = new Vector2(anchoredPos.transform.localPosition.x  + x * spaceSlot, anchoredPos.transform.localPosition.y - y * spaceSlot);

                var newSlot = new InventorySlot()
                {
                    go = Instantiate(sPrefab.gameObject, slotPos, Quaternion.identity, parent)
                };
                newSlot.go.transform.localPosition = slotPos;
                inventory.inventorySlots.Add(newSlot);
                
                x++;
            }
            
            ApplyItemOnSlot(inventory);
        }

        public void ApplyItemOnSlot(Inventory inventory)
        {
            for (int i = 0; i < inventory.itemsInventory.Count; i++)
            {
                inventory.inventorySlots[i].item = inventory.itemsInventory[i].item;
                inventory.inventorySlots[i].count = inventory.itemsInventory[i].count;
                inventory.inventorySlots[i].go.GetComponent<Image>().color = Color.blue;
            }
        }
    }

    [Serializable] public class PlayerInventory
    {
        public Items item;
        public int count;
    }
    
    [Serializable] public class InventorySlot
    {
        public GameObject go;
        public Items item;
        public int count;
    }

}
