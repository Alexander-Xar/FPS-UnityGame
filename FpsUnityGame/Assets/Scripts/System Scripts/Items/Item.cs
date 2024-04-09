
using UnityEngine;
/* The base item class. All items should deriv from this */
[CreateAssetMenu(fileName = "New Item", menuName = "Intentory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    //called when the item is pressed in the inventory
    public virtual void Use()
    {


        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
