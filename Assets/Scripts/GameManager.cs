using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int maxItem;
    public int currentItem;

    public int cornCount;
    public int tomatoCount;

    public Text playerhpText;
    public Text cornText;
    public Text tomatoText;

    private void Awake()
    {
        Instance = this;
        if (SceneManager.GetActiveScene().name == "Lev1") 
        {
            maxItem = 6; // Set max items for Level 1
        }
        else if (SceneManager.GetActiveScene().name == "Lev2") 
        {
            maxItem = 12; // Set max items for Level 2
        }

        currentItem = 0;
        cornCount = 0;
        tomatoCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void setPlayerHpText(string value)
    {
        playerhpText.text = "Cat's HP: " + value;
    }

    public void setCornText(string value)
    {
        cornText.text = "Corn: " + value;
    }

    public void setTomatoText(string value)
    {
        tomatoText.text = "Tomato: " + value;
    }
    //public void EndGame(bool isWin)
    //{
    //    PlayerPrefs.SetString("GameResult", isWin ? "You Win!" : "You Lose!");
    //    SceneManager.LoadScene("GameOver");
    //}

}
