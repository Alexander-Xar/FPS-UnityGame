using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public LayerMask movementMask; //filter raycasting

    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Create ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Ray hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Create ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Ray hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                RemoveFocus();
                
            }
        }
    }

    void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        
        
        focus = null;
    }
}
