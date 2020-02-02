using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGameGUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject gui;

    [Header("Fade Parameters")]
    [SerializeField]
    private float fadeIncrement = 0.2f; 
    [SerializeField]
    private float fadeTick = 0.2f;

    private Image panel;

    private void Awake() 
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
        SetGuiActive(false);
        StopAllCoroutines();
        StartCoroutine(FadeCorutine(-fadeIncrement,fadeTick));
    }

    public IEnumerator FadeCorutine(float increment, float tick)
    {
        Color c = panel.color;

        do
        {
            Debug.Log("Fade alpha " + c.a);
            c.a += increment;
            panel.color = c;
        
            yield return new WaitForSeconds(tick);
        } while(c.a > 0f && c.a < 1f);

        if(increment > 0)
        {
            SetGuiActive(true);
        }
    }

    public void SetGuiActive(bool value)
    {
        gui.SetActive(value);
    }

   public void PlayAgain()
   {
       int sceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadSceneAsync(sceneIndex);
   }

   public void QuitGame()
   {
       Application.Quit();
   }

   private void OnValidate() 
   {
       if(fadeTick < 0)
       {
           fadeTick = 0f;
       }

       if(fadeIncrement < 0)
       {
           fadeIncrement = 0.05f;
       }
   }
}
