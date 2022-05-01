using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEye : MonoBehaviour
{
    public GameObject[] eyeball;

    public void Update()
    {
        
    }


    /*
     * checks to see if collision will occur + it does.
     * Put fade into credits instead of deleting eyeballs
     */
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("eyeball"))
        {
            Debug.Log("eyeball enter");
        }
    }
    
}
