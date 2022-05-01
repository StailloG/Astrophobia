using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LookingIntoTelescope : MonoBehaviour
{
    //variables
    public TextMeshProUGUI text;
    public bool showText = false;
    public Animator transition;

    public void Start()
    {
        text.gameObject.SetActive(false); //text not available
        //transition = GetComponent<Animation>(); //get animation component

    }

    private void Update()
    {
        //if player enters trigger & presses 'E'
        if (showText == true && Input.GetKeyDown(KeyCode.E) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            text.gameObject.SetActive(true); //text available
            text.text = "I wonder what I will see...";

            //crossfade transition
            StartCoroutine(crossfade());

            //go to next scene after looking through telescope
            StartCoroutine(goToVideoScene());

        }

        //if in third scene
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            //if player enters trigger & presses 'E'
            if (showText == true && Input.GetKeyDown(KeyCode.E))
            {
                text.gameObject.SetActive(true); //text available
                text.text = "Was that star... Looking right back at me?"; //don't allow player to look back inside telescope
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

    public IEnumerator crossfade()
    {
        //crossfade transition
        transition.Play("crossfadeStart");

        //seconds before transitioning
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator goToVideoScene()
    {
        //seconds before transitioning
        yield return new WaitForSeconds(3f);

        //go to next scene
        SceneManager.LoadScene(1);
    }

    
}
