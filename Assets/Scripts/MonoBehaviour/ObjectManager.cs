using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe che gestisce la selezione multipla di oggetti
public class ObjectManager : MonoBehaviour
{
    // Dizionari che mappano gli object ID agli oggetti e i groupID agli objectID
    public Dictionary<int, HIntObject> mapObject;
    public Dictionary<int, List<int>> mapGroup;

    // Classe che contiene 
    [System.Serializable]
    public class Trigger
    {
        public int[] triggerID;
        public DIalogue triggeredDialogues;
    }

    public List<int[]> triggers;


    // Start is called before the first frame update
    void Start()
    {
        mapObject = new Dictionary<int, HIntObject>();
        mapGroup = new Dictionary<int, List<int>>();
        InitializeMaps();
    }

    public void InitializeMaps()
    {
        var objects = FindObjectsOfType<HIntObject>();
        foreach (var hintObj in objects)
        {
            mapObject.Add(hintObj.objectID, hintObj);
            Debug.Log("Added " + hintObj.objectID + " that has " + mapObject[hintObj.objectID].objectID);
            if (!mapGroup.ContainsKey(hintObj.groupID))
            {
                mapGroup.Add(hintObj.groupID, new List<int>());
            }

            mapGroup[hintObj.groupID].Add(hintObj.objectID);
        }
    }

    public void ActivateObject(int objectId)
    {
        var objectToChange = mapObject[objectId];
        objectToChange.setActive(true);

        foreach (var objID in mapGroup[objectToChange.groupID])
        {
            if (objID != objectToChange.objectID)
            {
                mapObject[objID].setActive(false);
            }
        }
    }

    public void CheckTriggered()
    {
        foreach(var trigger in triggers)
        {
            bool triggered = true;
            foreach(var id in trigger)
            {
                if (!mapObject[id].Active) {
                    triggered = false;
                }
            }
            if (triggered)
            {
                //T
            }
        }
    }
}
