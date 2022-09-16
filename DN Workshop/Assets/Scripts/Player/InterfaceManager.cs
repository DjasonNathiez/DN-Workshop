using UnityEngine;
using UnityEngine.UI;
using UsingInventory;

public class InterfaceManager : MonoBehaviour
    {
        public Inventory playerInventory;
        public int columns;
        public int lines;
        public float slotSpace;
        public Image inventorySlotPrefab;
        public Transform inventorySlotParent;
        public Transform anchoredPosSlot;

        private void Awake()
        {
            playerInventory = FindObjectOfType<Inventory>();
        }

        void Start()
        {
            UpdateSlots(playerInventory, lines, columns, inventorySlotPrefab, inventorySlotParent, slotSpace, anchoredPosSlot);
        }

        #region QUEST

        void OpenQuestPanel()
        {
            
        }

        void UpdateQuestHUD()
        {
            
        }

        #endregion

        #region INVENTORY
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
                inventory.inventorySlots[i].go.GetComponent<Image>().sprite = inventory.itemsInventory[i].item.icon;
            }
        }
        

        #endregion
      
    }


