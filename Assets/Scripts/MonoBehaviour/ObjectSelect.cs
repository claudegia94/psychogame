using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelect : MonoBehaviour
{
    public float selectionDistance = 2f;
    private ObjectManager manager;
    private HIntObject lastHighlighted;
    private void Start()
    {
        manager = FindObjectOfType<ObjectManager>();
        StartCoroutine("CheckHighlight");
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
                    if (Vector3.Distance(this.transform.position, hint.transform.position) < selectionDistance)
                    {

                        manager.ActivateObject(hint.objectID);
                    }
                }
            }
        }
    }

    IEnumerator CheckHighlight()
    {
        while (true) {
            if (Physics.Raycast(this.transform.position, this.transform.forward, out RaycastHit hitInfo))
            {
                var hint = hitInfo.transform.gameObject.GetComponent<HIntObject>();
                if (hint != null)
                {
                    if (Vector3.Distance(this.transform.position, hint.transform.position) < selectionDistance)
                    {
                        hint.setHighlighted(true);
                        lastHighlighted = hint;
                    }
                }
            }
            else if (lastHighlighted != null)
            {
                lastHighlighted.setHighlighted(false);
                lastHighlighted = null;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

}
