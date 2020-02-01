using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class PopupBaloon : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textArea;  

    

    public void SetText(string text)
    {
        textArea.text = text;
    }
}
