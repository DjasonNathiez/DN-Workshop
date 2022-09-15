using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public List<Inventory> inventories;
        public List<BagSlotObj> bagSlots;
        public int bagSlot;
        public GameObject slotPrefab;

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
            int x = 0;
            int y = 0;
            
            for (int i = 0; i < bagSlot; i++)
            {
                x++;
                Debug.Log(x);
                if (x >= maxColumn)
                {
                    x = 0;
                    y++;
                    Debug.Log(y);
                }
                
                var pos = new Vector2(slotPrefab.transform.position.x + x, slotPrefab.transform.position.y + y);

                var newBagSlot = new BagSlotObj
                {
                    go = Instantiate(slotPrefab, pos, Quaternion.identity)
                };
                        
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
                bagSlots[i].go.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
        }
    }
}
