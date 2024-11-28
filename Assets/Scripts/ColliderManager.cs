using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColliderManager : MonoBehaviour
{

    //ini taro di playernya kan ya
    Collision2D collision;
    public int maxHealth = 5;
    public int currHealth;
    public int damage = 1;

    void Start()
    {
        currHealth = maxHealth;
        GameManager.Instance.setPlayerHpText(currHealth.ToString());
        GameManager.Instance.setCornText(GameManager.Instance.cornCount.ToString());
        GameManager.Instance.setTomatoText(GameManager.Instance.tomatoCount.ToString());

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Annoyance")) 
        {
            Debug.Log("Annoyance hit detected!");

            // Reduce health
            currHealth -= damage;
            GameManager.Instance.setPlayerHpText(currHealth.ToString()); 
        
            Debug.Log("Current health = " + currHealth);

            // Check if health is 0 or below
            if (currHealth <= 0)
            {
                Debug.Log("Player is dead. Game Over!");
                SceneManager.LoadScene("GameOver"); 
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Tag: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            // Collect corn
            if (gameObject.CompareTag("Corn"))
            {
                GameManager.Instance.currentItem++;
                GameManager.Instance.cornCount += 1;
                Debug.Log("Corn collected. Current = " + GameManager.Instance.currentItem + " , Corn = " + GameManager.Instance.cornCount);
                GameManager.Instance.setCornText(GameManager.Instance.cornCount.ToString());
            }
            // Collect tomato
            else if (gameObject.CompareTag("Tomato"))
            {
                GameManager.Instance.currentItem++;
                GameManager.Instance.tomatoCount += 1;
                Debug.Log("Tomato collected. Current = " + GameManager.Instance.currentItem + " , Tomato = " + GameManager.Instance.tomatoCount);
                GameManager.Instance.setTomatoText(GameManager.Instance.tomatoCount.ToString());
            }

            Destroy(gameObject);  

      
            if (GameManager.Instance.currentItem >= GameManager.Instance.maxItem)
            {
                // If in level 1, proceed to level 2
                if (GameManager.Instance.maxItem == 6) // Level 1 max item count
                {
                    Debug.Log("Level 1 completed. Transitioning to Level 2.");
                    GameManager.Instance.ChangeScene("Lev2"); 
                    GameManager.Instance.maxItem = 12; 
                    GameManager.Instance.currentItem = 0; 
                    GameManager.Instance.cornCount = 0;   
                    GameManager.Instance.tomatoCount = 0; 
                }
                // If in level 2, check for win condition
                else if (GameManager.Instance.maxItem == 12) 
                {
                    if (GameManager.Instance.currentItem >= 12) 
                    {
                        Debug.Log("You Win! All items collected!");
                        SceneManager.LoadScene("GameWin");
                    }
                }
            }
        }
    }




}
