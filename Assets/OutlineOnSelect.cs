using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public class OutlineOnSelect : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private GameObject FocusedObject;

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        if (FocusedObject != oldFocusObject)
        {
            // Deselect the old selected GameObject is not null
            if (oldFocusObject != null)
            {
                var outlineComponent = oldFocusObject.GetComponent<Outline>();
                if (outlineComponent != null)
                {
                    outlineComponent.enabled = false;
                }
            }

            // Select the selected GameObject is not null
            if (FocusedObject != null)
            {
                var outlineComponent = FocusedObject.GetComponent<Outline>();
                if (outlineComponent != null)
                {
                    outlineComponent.enabled = true;
                }
            }
        }
    }
}
