using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    //variables
    public Animator transition;
    public GameObject toCreditsTransition;

    private void Start()
    {
        toCreditsTransition.SetActive(false);
    }

    void Update()
    {
        StartCoroutine(toCredits());
    }

    IEnumerator toCredits()
    {
        //crossfade transition looking out of telescope
        transition.Play("crossfadeEnd");

        yield return new WaitForSeconds(30f);

        //transition to credits
        toCreditsTransition.SetActive(true);

        yield return new WaitForSeconds(2f);

        //go to credits scene
        SceneManager.LoadScene(3);

    }
}
