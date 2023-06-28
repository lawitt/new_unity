using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Script : MonoBehaviour
{
    //guns are placed in the game, when the player collides with the collider of the gun, the gun starts to shoot bullets

    //gun bullet time delay
    private float _nextGunFireTime = 1f;
    [SerializeField]
    private float _gunFireCoolDownTime = 5f;

    private bool _shoot = false;

    [SerializeField]
    private GameObject _gunBulletPrefabLeft;

    [SerializeField]
    private GameObject _gunBulletPrefabRight;

    //to decide in which direction the gun shoots
    [SerializeField]
    private bool _directionRight;

    //the gun shoots bullets horizontally
    void Update()
    {
        if (_shoot && _nextGunFireTime < Time.time)
        {
            if(_directionRight)
            {
                Instantiate(_gunBulletPrefabRight, transform.position + new Vector3(0.7f, 0f, 0f), Quaternion.identity);
                _nextGunFireTime = Time.time + _gunFireCoolDownTime;
            }
            else 
            {
                Instantiate(_gunBulletPrefabLeft, transform.position + new Vector3(0.7f, 0f, 0f), Quaternion.identity);
                _nextGunFireTime = Time.time + _gunFireCoolDownTime;
            }
        }
    }

    //the gun starts shooting, when player collides with collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _shoot = true;
        }
    }
}
