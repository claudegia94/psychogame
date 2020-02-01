using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIntObject : MonoBehaviour
{
    public string objectID;
    public string groupID;
    public AudioClip objectClip = null;
    public bool Active { get { return isActive; } }
    private cakeslice.Outline outline;
    private bool isHighlighted = false; 
    private bool isActive = false;
    private bool isDefinitive = false;
    

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
        if (!isDefinitive && isActive != active)
        {
            isActive = active;
            isHighlighted = false;
            outline.enabled = active;
            outline.color = 1;
        }
    }

    public void setDefinitive()
    {
        isActive = true;
        isDefinitive = true;
        outline.enabled = true;
        outline.color = 2;
    }
}
