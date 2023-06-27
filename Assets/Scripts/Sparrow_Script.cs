using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparrow_Script : MonoBehaviour
{

    //if the player gets the sparrow, he receives one extra live
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            other.GetComponent<Player_Script>().recovery();
            Destroy(this.gameObject);
        }
    }
}
