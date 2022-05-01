using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //variables
    public Transform player;
    private int speedToPlayer = 10;
    private int speedToRotate = 4;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(wait());
    }

    /*
     * eyeballs wait a certain amount of time before rotating to look at player
     */
    IEnumerator wait()
    {
        yield return new WaitForSeconds(4.5f);

        //find player transformation
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //transform.LookAt(player); //used to look at player right away

        //gradually look at player
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speedToRotate * Time.deltaTime);

        //move towards player
        if (Vector3.Distance(transform.position, player.position) >= 5)
        {
            transform.position += transform.forward * speedToPlayer * Time.deltaTime;
        }
    }

}
