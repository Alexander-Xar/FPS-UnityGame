
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        if (item != null)
        {
            Debug.Log("Picking up item " + item.name);

            
            if (Inventory.instance.IsSpaceAvailable())
            {
                
                bool wasPickedUp = Inventory.instance.Add(item);

                // If the item was successfully picked up, destroy the pickup object
                if (wasPickedUp)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.LogWarning("Inventory is full. Cannot pick up item.");
            }
        }
        else
        {
            Debug.LogWarning("Item is null!");
        }
    }


}
