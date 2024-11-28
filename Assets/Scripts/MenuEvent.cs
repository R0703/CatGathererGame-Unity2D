using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEvent : MonoBehaviour
{
    public GameObject menuPanel;
    bool isActive = false;
    void Start()
    {
        if(menuPanel != null)
        {
            menuPanel.SetActive(isActive);
        }
        else
        {
            Debug.LogError("menu panel not set");
        }
    }

    public void toggleMenuPanel()
    {
        if (menuPanel != null)
        {
            isActive = !isActive;
            menuPanel.SetActive(isActive);
        }
        Debug.Log("button menu is clicked");
    }

    public void quitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        
    }
}
