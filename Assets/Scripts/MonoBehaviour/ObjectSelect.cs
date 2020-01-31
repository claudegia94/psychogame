using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelect : MonoBehaviour
{
    private ObjectManager manager;

    private void Start()
    {
        manager = FindObjectOfType<ObjectManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            if (Physics.Raycast(this.transform.position, this.transform.forward, out RaycastHit hitInfo))
            {
                
                var hint = hitInfo.transform.gameObject.GetComponent<HIntObject>();
                if (hint != null)
                { 
                    manager.ActivateObject(hint.objectID);
                }
            }
        }
    }
}
