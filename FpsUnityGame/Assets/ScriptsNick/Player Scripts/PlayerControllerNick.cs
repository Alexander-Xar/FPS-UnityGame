using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public LayerMask movementMask; // Filter raycasting

    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 3f, movementMask); //Adjustable radius

            Interactable closestInteractable = GetClosestInteractable(colliders);

            if (closestInteractable != null)
            {
                SetFocus(closestInteractable);
            }
            else
            {
                RemoveFocus();
            }
        }
        
    }

    Interactable GetClosestInteractable(Collider[] colliders)
    {
        Interactable closestInteractable = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                float distanceToInteractable = Vector3.Distance(transform.position, collider.transform.position);
                if (distanceToInteractable < closestDistance)
                {
                    closestInteractable = interactable;
                    closestDistance = distanceToInteractable;
                }
            }
        }

        return closestInteractable;
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != null)
        {
            if (newFocus != focus)
            {
                if (focus != null)
                    focus.OnDefocused();

                focus = newFocus;
            }
            newFocus.OnFocused(transform);
        }
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
    }
}
