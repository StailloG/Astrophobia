using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterVideo : MonoBehaviour
{
    void Update()
    {
        //go to previous scene after watching video
        StartCoroutine(goToNextScene());
    }

    IEnumerator goToNextScene()
    {
        //seconds before transitioning
        yield return new WaitForSeconds(7f);

        //go to next scene
        SceneManager.LoadScene(2);
    }
}
