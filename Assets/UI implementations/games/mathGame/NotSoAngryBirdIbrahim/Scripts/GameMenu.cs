using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject bird;
    [SerializeField] private GameObject equation;
    [SerializeField] private GameObject box1,box2,box3;
    [SerializeField] private GameObject MenuBtn;
    [SerializeField] private GameObject MenuPanel;
    // Update is called once per frame
    public void OnMenuActive()
    {
        bird.SetActive(false);
        equation.SetActive(false);
        box1.SetActive(false);
        box2.SetActive(false);
        box3.SetActive(false);
        MenuBtn.SetActive(true);
        MenuPanel.SetActive(true);
    }
    public void OnMenuQuit()
    {
        bird.SetActive(true);
        equation.SetActive(true);
        box1.SetActive(true);
        box2.SetActive(true);
        box3.SetActive(true);
        MenuBtn.SetActive(true);
        MenuPanel.SetActive(false);
    }
}
