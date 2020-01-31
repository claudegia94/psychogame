using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIntObject : MonoBehaviour
{
    public int objectID;
    public int groupID;
    private Renderer rend;
    private Color originalColor;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void setColorSelected()
    {
        rend.material.color = Color.black;
    }
}
