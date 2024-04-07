using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            Destroy(gameObject);
        }
    }
    #endregion

    public int space = 2;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count > space)
            {

                Debug.Log("Not enough room.");
                return false;
            }
            items.Add(item);
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public bool IsSpaceAvailable()
    {
        return items.Count < space;
    }
}
