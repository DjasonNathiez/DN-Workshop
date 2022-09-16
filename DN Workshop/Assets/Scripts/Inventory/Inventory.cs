using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UsingInventory
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory instance;
        
        public List<PlayerInventory> itemsInventory;
        public List<InventorySlot> inventorySlots;
        public List<ItemBag> bags;
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
                Destroy(this);
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

        public void AddToInventory(Item item = null)
        {
            int number = 1;
            var newItem = new PlayerInventory()
            {
                item = item,
                count = number
            }; 
            
            itemsInventory.Add(newItem);
            
            QuestManager.instance.AddToQuestCount(item, number);
        }
    }

    [Serializable] public class PlayerInventory
    {
        [FormerlySerializedAs("item")] public Item item;
        public int count;
    }
    
    [Serializable] public class InventorySlot
    {
        public GameObject go;
        [FormerlySerializedAs("item")] public Item item;
        public int count;
    }

}
