
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    InventorySlot[] slots;

    Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }


    void Update()
    {
       
        if (Input.GetButtonDown("Inventory"))
        {
            ToggleInventoryUI();
        }
    
    }

    void UpdateUI()
    {
        Debug.Log("UPDATING UI");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }


    void ToggleInventoryUI()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);

        // Lock or unlock cursor based on inventory UI state
        if (inventoryUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true; 
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false; 
        }
    }
}
