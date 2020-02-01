using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.FirstPerson;

// Classe che gestisce la selezione multipla di oggetti
public class ObjectManager : MonoBehaviour
{
    // Dizionari che mappano gli object ID agli oggetti e i groupID agli objectID
    public Dictionary<string, HIntObject> mapObject;
    public Dictionary<string, List<string>> mapGroup;
    
    
    // Classe che contiene 
    [System.Serializable]
    public class Trigger
    {
        public string[] triggerIDs;
        public string dialogueTrigger;
    }

    public List<Trigger> triggers;
    public AudioClip combinationClip;
    public AudioClip pencilClip;

    private bool isShowingText = false;
    private List<string> textToShow;
    private PopupBaloon baloon;
    private FirstPersonController controller;
    private DialogueReader reader;
    private AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<FirstPersonController>();
        baloon = FindObjectOfType<PopupBaloon>();
        aSource = GetComponent<AudioSource>();
        reader = new DialogueReader();
        if (baloon != null)
        {
            baloon.transform.gameObject.SetActive(false);
        }

        mapObject = new Dictionary<string, HIntObject>();
        mapGroup = new Dictionary<string, List<string>>();
        InitializeMaps();
    }

    private void Update()
    {
        if (isShowingText && Input.GetKeyUp(KeyCode.Space)) {
            DigestNextLine();
        }
    }

    public void InitializeMaps()
    {
        var objects = FindObjectsOfType<HIntObject>();
        foreach (var hintObj in objects)
        {
            mapObject.Add(hintObj.objectID, hintObj);
            if (!mapGroup.ContainsKey(hintObj.groupID))
            {
                mapGroup.Add(hintObj.groupID, new List<string>());
            }

            mapGroup[hintObj.groupID].Add(hintObj.objectID);
        }
    }

    public void ActivateObject(string objectId)
    {
        if (!mapObject[objectId].Active)
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
            PlayAudioClip(mapObject[objectId].objectClip);
            StartShowingText("Room02_mente", mapObject[objectId].groupID, objectId);
        }
    }

    public void CheckTriggered()
    {
        foreach(var trigger in triggers)
        {
            bool triggered = true;
            foreach(var id in trigger.triggerIDs)
            {
                
                if (!mapObject[id].Active) {
                    triggered = false;
                }
            }
            if (triggered)
            {
                foreach (var id in trigger.triggerIDs)
                {

                    mapObject[id].setDefinitive();
                }

                PlayAudioClip(combinationClip);
                StartShowingText("Room02_mente", "ObjectList06", trigger.dialogueTrigger);
                triggers.Remove(trigger);
                break;
            }
        }
    }

    private void StartShowingText(string room, string objectID, string groupID)
    {
        controller.enabled = false;
        textToShow = reader.ReadDialog(room, objectID, groupID);
        baloon.transform.gameObject.SetActive(true);
        this.isShowingText = true;
        DigestNextLine();
    }

    private void StopShowingText()
    {
        controller.enabled = true;
        baloon.transform.gameObject.SetActive(false);
        this.isShowingText = false;
    }

    private void DigestNextLine()
    {
        if (textToShow.Count <= 0)
        {
            StopShowingText();
            CheckTriggered();
        }
        else
        {
            PlayAudioClip(pencilClip);
            baloon.SetText(textToShow[0]);
            textToShow.RemoveAt(0);
        }

    }

    private void PlayAudioClip(AudioClip clip)
    {
        if (clip != null) {
            aSource.clip = clip;
            aSource.Play();
                }
    }
}
