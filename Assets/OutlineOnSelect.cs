using cakeslice;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class OutlineOnSelect : MonoBehaviour, IFocusable
{
    private Outline outlineComponent;

    void Start()
    {
        this.outlineComponent = this.GetComponent<Outline>();

        // Disable the component on start. 
        OnFocusExit(); 
    }

    public void OnFocusEnter()
    {
        if (this.outlineComponent != null)
        {
            this.outlineComponent.enabled = true;
        }
    }

    public void OnFocusExit()
    {
        if (this.outlineComponent != null)
        {
            this.outlineComponent.enabled = false;
        }
    }
}
