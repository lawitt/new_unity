using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor_Script : MonoBehaviour
{
    //when the player jumps on the same platform as the tractor, then the tractor starts moving, when they collide, the player loses a live
    [SerializeField]
    private bool _movetoRight;

    [SerializeField]
    private GameObject _player;

    private bool _move = false;

    //indicates when tractor should stop
    [SerializeField]
    private int _arrived = 150;

    //to detect direction of movement
    private float _directionX;

    private float _boundaryX;

    void Start ()
    {
        //select the dierection of movement
        if (_movetoRight)
        {
            _directionX = 0.05f;
            _boundaryX = 10;
        }
        else 
        {
            _directionX = -0.05f;
            _boundaryX = -10;
        }
    }

    //tractor moves, after activating until reaching the boundary
    void Update()
    {
        //move the tractor in specific direction
        if (_move && _arrived >= 0) 
        {
            transform.position = new Vector3((transform.position.x + _directionX), transform.position.y, transform.position.z);
            _arrived--;
        }

        //if player is in boundary, start the move
        if ((_player.transform.position.x - transform.position.x) >= _boundaryX && (transform.position.y - _player.transform.position.y) <= 1)
        {
            _move = true;
        }
    }

    //damage the player, when colliding with the tractor
    void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            other.GetComponent<Player_Script>().damage();
            Debug.Log("Collision with tractor");
        }
    }
}
