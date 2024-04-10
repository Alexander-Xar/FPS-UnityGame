using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    
    public EquipmentManager equipmentManager;
    public ItemPickup runeSwordPickup;
    public ItemPickup runeHammerPickup;
    private bool hasWon = false;

    private bool AreBothItemsPickedUp()
    {
        // Check if both Rune Sword and Rune Hammer pickups are destroyed
        return runeSwordPickup == null && runeHammerPickup == null;
    }
    private bool IsWinConditionMet()
    {
        // Check if both items are picked up
        return AreBothItemsPickedUp();
    }

    private void Update()
    {
        if (!hasWon && IsWinConditionMet())
        {
            // Call the GameManager's win method
            GameManager.instance.PlayerWins();

            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            hasWon = true;
        }
    }
}
