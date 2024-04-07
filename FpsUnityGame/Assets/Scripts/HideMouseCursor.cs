using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouseCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        // Hide the cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
