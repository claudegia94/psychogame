﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueReader
{
    public List<string> ReadDialog(string room, string location, string name)
    {
        List<string> text = new List<string>();
        string line = null;
        using (StreamReader file = new StreamReader(Application.dataPath + "/Rooms/" + room + "/" + location + "/" + name + ".txt"))
        {
            while ((line = file.ReadLine()) != null)
                text.Add(line);
        }
        return text;
    }
}
