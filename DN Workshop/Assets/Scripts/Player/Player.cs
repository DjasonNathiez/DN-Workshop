using System;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public List<Inventory> inventories;
        public List<BagSlotObj> bagSlots;
        private int bagSlot;
        public Items_Bag[] bags;
        public int maxBags;
       
        
        public GameObject slotPrefab;
        public Transform slotParent;
        public float spaceSlot;
        
        public int maxColumn;
        public int maxLines;

        [Serializable] public class BagSlotObj
        {
            public GameObject go;
            public Items item;
            public int count;
        }

        [Serializable] public class Inventory
        {
            public Items item;
            public int countOfObject;
        }

        private void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            IUpdateSlots();
        }

        void AddToInventory(Items i, int count = 1)
        {
            var newItem = new Inventory
            {
                item = i,
                countOfObject = count
            };
            
            inventories.Add(newItem);
        }

        void IUpdateSlots()
        {
            foreach (var b in bags)
            {
                bagSlot += b.slots;
            }
            
            Debug.Log(bagSlot);
            
            int x = 0;
            int y = 0;
            
            for (int i = -1; i < bagSlot; i++)
            {
                x++;
                Debug.Log(x);
                if (x >= maxColumn)
                {
                    x = 0;
                    y++;
                    Debug.Log(y);
                }
                
                var pos = new Vector2(slotPrefab.transform.position.x + x * spaceSlot, slotPrefab.transform.position.y + y * spaceSlot);

                var newBagSlot = new BagSlotObj
                {
                    go = Instantiate(slotPrefab, pos, Quaternion.identity, slotParent)
                    
                };
                newBagSlot.go.transform.position = pos;   
                bagSlots.Add(newBagSlot);
            }
            IUpdateItems();
        }
        
        void IUpdateItems()
        {
            for (int i = 0; i < inventories.Count; i++)
            {
                bagSlots[i].item = inventories[i].item;
                bagSlots[i].count = inventories[i].countOfObject;
                bagSlots[i].go.GetComponent<Image>().color = Color.blue;
            }
        }
    }
}
