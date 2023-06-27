using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube_Script : MonoBehaviour
{
    //some cubes should move along the X-Axis and should stop, when the player jumps on top of the cube
    [SerializeField]
    private float _boundaryLeft;

    [SerializeField]
    private float _boundaryRight;

    private bool _directionRight;

    private bool _move;

    void Update()
    {
        //select the direction, the cube should move
        if(transform.position.x >= _boundaryRight)
        {
            _directionRight = false;
        }

        if(transform.position.x <= _boundaryLeft) 
        {
            _directionRight = true;
        }

        //moves the cube, if player is not on top
        if (_move) 
        {
            if (_directionRight)
            {
                transform.position = new Vector3((transform.position.x + 0.01f), transform.position.y, transform.position.z);
            }
            else 
            {
                transform.position = new Vector3((transform.position.x - 0.01f), transform.position.y, transform.position.z);
            }
        }

    }

    //detects, whether the player is on top of the cube 
    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) {
            _move = false;
        }
        else
        {
            _move = true;
        }
    }

}
