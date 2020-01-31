using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIntObject : MonoBehaviour
{
    public int objectID;
    public int groupID;
    private Renderer rend;
    private Color originalColor;
    private bool isActive = false;
    

    public void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void setActive(bool active)
    {
        Debug.Log("This " + objectID + " is setting " + active);
        if (this.isActive != active)
        {
            this.isActive = active;
            rend.material.color = (this.isActive) ? Color.red : this.originalColor;
            Debug.Log(rend.material.color);
            
        }
    }
}
