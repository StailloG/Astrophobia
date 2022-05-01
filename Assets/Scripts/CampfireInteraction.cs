using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CampfireInteraction : MonoBehaviour
{
    //variables
    public TextMeshProUGUI text;
    public bool showText = false;

    public void Start()
    {
        text.gameObject.SetActive(false); //text not available
    }

    private void Update()
    {
        //if player enters trigger & presses 'E'
        if(showText == true && Input.GetKeyDown(KeyCode.E) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            text.gameObject.SetActive(true); //text available
            text.text = "I already ate the last s'more. I wish I packed more.";
        }

        //if in third scene
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            //if player enters trigger & presses 'E'
            if (showText == true && Input.GetKeyDown(KeyCode.E))
            {
                text.gameObject.SetActive(true); //text available
                text.text = "Can I make a torch out of this thing?!";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if player collides with campfire
        if (other.tag == "Player")
        {
            showText = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        showText = false;
        text.gameObject.SetActive(false); //text not available
    }

}
