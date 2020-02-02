using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameGUIController : MonoBehaviour
{
   public void PlayAgain()
   {
       int sceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadSceneAsync(sceneIndex);
   }

   public void QuitGame()
   {
       Application.Quit();
   }
}
