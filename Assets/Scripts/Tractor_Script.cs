using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor_Script : MonoBehaviour
{
    //when the player jumps on the same platform as the tractor, then the tractor starts moving
    [SerializeField]
    private bool _movetoRight;

    [SerializeField]
    private Collider BC;

    private bool _move = false;

    void Update()
    {
        if (_movetoRight) 
        {
            if (_move) 
            {
                transform.position = new Vector3((transform.position.x + 0.03f), transform.position.y, transform.position.z);
            }
        }
        else 
        {
            if (_move) 
            {
                transform.position = new Vector3((transform.position.x - 0.03f), transform.position.y, transform.position.z);
            }
        }
        
    }

    void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag("Player") && other == BC) 
        {
            other.GetComponent<Player_Script>().damage();
            Debug.Log("Collision with tractor");
        }

        if (other.CompareTag("Player")) 
        {
            _move = true;
        }
    }
}
