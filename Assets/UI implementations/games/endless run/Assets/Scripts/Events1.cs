using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Events1 : MonoBehaviour
{
  public void R�playGame()
    {
        SceneManager.LoadScene("Endless");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
