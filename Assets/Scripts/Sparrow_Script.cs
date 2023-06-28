using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparrow_Script : MonoBehaviour
{
    //sparrow appears on top of level and flies down with time
    //if player catches bird, the player receives an extra live
    private float positionX;
    private float positionY;
    private int _count = 0;

    //start at certain position
    void Start ()
    {
        transform.position = new Vector3(2.5f, 27.2f, 0f);
    }

    //sparrow flies down the environment randomly
    void Update()
    {
        positionX = transform.position.x + Random.Range(-0.2f, 0.2f);
        positionY = transform.position.y + Random.Range(-0.1f, 0.05f);
        if (positionX >= -20 && positionX <= 25)
        {
            transform.position = new Vector3(positionX, transform.position.y, 0f);
        }
        if (positionY >= -10 && positionY <= 30 && _count % 5 == 0)
        {
            transform.position = new Vector3(transform.position.x, positionY, 0f);
        }
        _count++;
    }

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
