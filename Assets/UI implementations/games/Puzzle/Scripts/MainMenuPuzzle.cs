using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPuzzle : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void LoadaScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Games");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    public void InfoButton()
    {
        panel.SetActive(true);
    }

    public void CloseInfoButton()
    {
        panel.SetActive(false);
    }
}
