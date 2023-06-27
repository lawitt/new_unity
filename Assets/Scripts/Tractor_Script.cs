using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor_Script : MonoBehaviour
{
    //when the player jumps on the same platform as the tractor, then the tractor starts moving
    [SerializeField]
    private bool _movetoRight;

    [SerializeField]
    private GameObject _player;

    private bool _move = false;

    private int _there = 0;

    void Update()
    {
        if (_movetoRight) 
        {
            if (_move && _there <= 200) 
            {
                transform.position = new Vector3((transform.position.x + 0.03f), transform.position.y, transform.position.z);
                _there++;
            }

            if ((_player.transform.position.x - transform.position.x) >= 10 && (transform.position.y - _player.transform.position.y) <= 1)
            {
                _move = true;
            }
        }
        else 
        {
            if (_move && _there <= 200) 
            {
                transform.position = new Vector3((transform.position.x - 0.03f), transform.position.y, transform.position.z);
                _there++;
            }

            if ((_player.transform.position.x - transform.position.x) >= -10 && (transform.position.y - _player.transform.position.y) <= 1)
            {
                _move = true;
            }
        }

        
    }


    void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            other.GetComponent<Player_Script>().damage();
            Debug.Log("Collision with tractor");
        }
    }
}
