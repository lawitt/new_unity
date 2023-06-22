using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    //camera should follow player = target

    [SerializeField]
    private Transform target;

    public Vector3 offset;

    //put camera at start position
    void Start()
    {
        offset = transform.position - target.transform.position;   
    }

    //camera follows player
    void LateUpdate()
    {
        //null check
        if( target != null)
        {
            //get current position and place camera there
            Vector3 newPosition = target.transform.position + offset;
            transform.position = newPosition;
        }
    
    }
}
