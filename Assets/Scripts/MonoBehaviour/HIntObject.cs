using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIntObject : MonoBehaviour
{
    public int objectID;
    public int groupID;
    public bool Active { get { return isActive; } }
    private cakeslice.Outline outline;
    private bool isHighlighted = false; 
    private bool isActive = false;
    

    public void Start()
    {
        outline = GetComponent<cakeslice.Outline>();
        outline.enabled = false;
    }

    public void setHighlighted(bool highlighted)
    {
        if (!isActive && isHighlighted != highlighted)
        {
            isHighlighted = highlighted;
            outline.enabled = highlighted;
            outline.color = 0;
        }
    }

    public void setActive(bool active)
    {
        if (isActive != active)
        {
            isActive = active;
            isHighlighted = false;
            outline.enabled = active;
            outline.color = 1;
        }
    }
}
