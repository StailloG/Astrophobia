using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TentInteraction : MonoBehaviour
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
        if (showText == true && Input.GetKeyDown(KeyCode.E) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            text.gameObject.SetActive(true); //text available
            text.text = "I'm not tired yet.";
        }

        //if in third scene
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            //if player enters trigger & presses 'E'
            if (showText == true && Input.GetKeyDown(KeyCode.E))
            {
                text.gameObject.SetActive(true); //text available
                text.text = "How can I sleep knowing they're watching me?!";
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
