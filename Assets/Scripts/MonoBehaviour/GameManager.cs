using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private EndGameGUIController endGameGUI;

    private ObjectManager objectManager;

    private bool isGameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        objectManager = GetComponent<ObjectManager>();
        endGameGUI.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectManager.CheckVictoryCondition() && !isGameEnded)
        {
            isGameEnded = true;
            endGameGUI.FadeIn();
        }
    }
}
