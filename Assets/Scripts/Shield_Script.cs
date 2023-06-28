using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Script : MonoBehaviour
{
    //protective shield appears in game and protects player for certain amount of time against eagles

    //set time and bar, the protective shield protects
    private int _maxTime = 3000;
    private int _currentTime;
    private bool _started = false; 

    [SerializeField]
    private TimeBar_Script _shieldBar;

    [SerializeField]
    private GameObject _player;

    void Start ()
    {
        //start time
        _currentTime = _maxTime;
        _shieldBar.setMaxTime(_maxTime);
    }

    void Update()
    {
        //when collected the shield, the shield is on top of player
        if (_started) 
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y+2f,(_player.transform.position.z));

        }

        //time reduces
        _currentTime--;
        _shieldBar.updateTime(_currentTime);

        //when time is up, the time bar gets destroied and shield gets destroied
        if (_currentTime <= 0)
        {
            _shieldBar.hideMesh();
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //when colliding with enenmy, the enemy gets destroied
        if (other.CompareTag("Enemy") && _started) 
        {
            Destroy(other.gameObject);
        }

        //detects when player collides with shield, to start shield
        if (other.CompareTag("Player") && !_started) 
        {
            _shieldBar.showMesh();
            _started = true;
        }
    }

}
