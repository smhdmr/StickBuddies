using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroryer : MonoBehaviour
{
    public GameObject Obstacle;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(WaitFor());
        }
    }
    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(0.7f);

        Obstacle.SetActive(false);
    }
}
