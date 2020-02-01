using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    public List<string> ReadDialog(string room, string location, string name)
    {
        List<string> text = new List<string>();
        string line = null;
        using (StreamReader file = new StreamReader("Assets/Rooms/" + room + "/" + location + "/" + name + ".txt"))
        {
            while ((line = file.ReadLine()) != null)
                text.Add(line);
        }
        return text;
    }
}
