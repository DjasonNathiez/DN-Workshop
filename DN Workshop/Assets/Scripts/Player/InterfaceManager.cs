using System;
using Inventory;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : UIInventoryInterface
    {
        public Inventory.Inventory playerInventory;
        public int columns;
        public int lines;
        public float slotSpace;
        public Image inventorySlotPrefab;
        public Transform inventorySlotParent;
        public Transform anchoredPosSlot;

        private void Awake()
        {
            playerInventory = FindObjectOfType<Inventory.Inventory>();
        }

        // Start is called before the first frame update
        void Start()
        {
            UpdateSlots(playerInventory, lines, columns, inventorySlotPrefab, inventorySlotParent, slotSpace, anchoredPosSlot);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }


