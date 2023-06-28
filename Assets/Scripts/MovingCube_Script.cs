using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube_Script : MonoBehaviour
{
    //some cubes move along the X-Axis, so the player reaches other cubes, which the player can not reach with jumping
    //the cubes just move between two boundaries
    [SerializeField]
    private float _boundaryLeft;
    [SerializeField]
    private float _boundaryRight;

    private bool _directionRight;

    void Update()
    {
        //if cube reaches boundary, change direction
        if(transform.position.x >= _boundaryRight)
        {
            _directionRight = false;
        }

        if(transform.position.x <= _boundaryLeft) 
        {
            _directionRight = true;
        }

        //move in the certain direction
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
