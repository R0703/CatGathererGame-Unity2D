using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollideHandlerdiKelas : MonoBehaviour
{
    private string title;
    private string information;
    public GameObject informationPanel;
    public Text titleInformation;
    public Text informationDetail;
    void Start()
    {
        if (informationPanel == null)
        {
            informationPanel = GameObject.Find("InformationPanel").GetComponent<RectTransform>().gameObject;
            titleInformation = GameObject.Find("TitleInformation").GetComponent<Text>();
            informationDetail = GameObject.Find("Information").GetComponent<Text>();
        }

        if (informationPanel != null)
        {
            Debug.Log("succesfully loaded info panel");
            informationPanel.SetActive(false);
        }
        else
        {
            Debug.Log("error info panel");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sunflower"))
        {
            title = "A tall Sunflower";
            information = "a bit odd how there's only one in this entire island";
        }
        else if (collision.gameObject.CompareTag("AppleTree"))
        {
            title = "Apple tree";
            information = "Maybe if u shake the tree, delicious apples will fall down";
        }
        else if (collision.gameObject.CompareTag("Fence"))
        {
            title = "Fence";
            information = "Careful, white cats really hate water";
        }
        else if (collision.gameObject.CompareTag("Annoyance"))
        {
            title = "Oh no!";
            information = "Careful!";
        }

        if (informationPanel != null && titleInformation != null && informationDetail != null)
        {
            titleInformation.text = title;
            informationDetail.text = information;
            informationPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if(informationPanel != null)
            {
                informationPanel.SetActive(false);
            }
        }
    }
}
