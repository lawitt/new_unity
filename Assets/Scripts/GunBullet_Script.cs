using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet_Script : MonoBehaviour
{
    //gun fires bullets, which damage the player, when they collide
    
    [SerializeField]
    private float _gunBulletSpeed = 3f;

    [SerializeField]
    private bool _directionRight;

    void Update()
    {
        //bullet has certain speed
        if(_directionRight)
        {
            transform.Translate(Vector3.right * _gunBulletSpeed * Time.deltaTime);
        }
        else 
        {
            transform.Translate(Vector3.left * _gunBulletSpeed * Time.deltaTime);
        }

        //if bullet reaches right or left boundary, it gets destroyed
        if (transform.position.x > 40f || transform.position.x < -40f) 
        {
            Destroy(this.gameObject);
        }
    }

    //when player collides with bullet, the player gets damaged
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            other.GetComponent<Player_Script>().damage();
        }
    }



}
