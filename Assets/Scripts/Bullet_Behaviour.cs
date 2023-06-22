using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behaviour : MonoBehaviour
{
    //player fires bullets, which can shoot the enemies to save the life of the player

    [SerializeField]
    private float _bulletSpeed = 5f;

    void Update()
    {
        //bullet has certain speed
        transform.Translate(Vector3.up * _bulletSpeed * Time.deltaTime);

        //if bullet reaches top, it gets destroyed
        if (transform.position.y > 40f) 
        {
            Destroy(this.gameObject);
            //destroy
        }
    }
}
