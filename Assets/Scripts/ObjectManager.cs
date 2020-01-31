using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Dictionary<int, HIntObject> mapObject;
    public Dictionary<int, int[]> mapGroup;


    // Start is called before the first frame update
    void Start()
    {
        mapObject = new Dictionary<int, HIntObject>();
        mapGroup = new Dictionary<int, int[]>();
    }

    public void InitializeMaps()
    {
        var hintObjects = FindObjectsOfType<HIntObject>();
        foreach(var hintObj in hintObjects)
        {
            mapObject.Add(hintObj.objectID, hintObj);
            mapGroup.Add(hintObj.groupID, hintObj.objectID);
        }
    }
}
