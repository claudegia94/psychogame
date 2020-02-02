using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [Header("Fade Parameters")]
    [SerializeField]
    private float fadeIncrement = 0.2f; 
    [SerializeField]
    private float fadeTick = 0.2f;

    private Image panel;

    private void Start() 
    {
        panel = GetComponent<Image>();    
    }

    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeCorutine(fadeIncrement, fadeTick));
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        Debug.Log("Fade Out");
        StartCoroutine(FadeCorutine(-fadeIncrement,fadeTick));
    }

    IEnumerator FadeCorutine(float increment, float tick)
    {
        Color c = panel.color;

        do{
            Debug.Log("Fade alpha " + c.a);
            c.a += increment;
            panel.color = c;

            yield return new WaitForSeconds(tick);
        } while(c.a > 0 && c.a < 1);
    }
}
