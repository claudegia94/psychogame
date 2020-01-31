using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueLines", menuName = "ScriptableObjects/DialogueLines", order = 1)]
public class DIalogue : ScriptableObject
{
    
    public List<string> dialogueLines;
}
