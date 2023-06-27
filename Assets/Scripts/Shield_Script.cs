using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Script : MonoBehaviour
{
    private int _maxTime = 5000;
    private int _currentTime;
    private bool _started = false; 

    [SerializeField]
    private ShieldBar_Script _shieldBar;

    void Start ()
    {
        _currentTime = _maxTime;
        _shieldBar.setMaxTime(_maxTime);
    }

    void Update()
    {
        _currentTime--;
        _shieldBar.updateTime(_currentTime);
        if (_currentTime <= 0)
        {
            _shieldBar.hideMesh();
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && _started) 
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player") && !_started) 
        {
            _shieldBar.showMesh();
            _started = true;
        }
    }

}
