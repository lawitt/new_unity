using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{

    [SerializeField]
    private UI_Script _uiManager;

    [SerializeField] 
    private Spawn_Manager _spawnManager;

    [SerializeField]
    private Player_Script _player;

    void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            _spawnManager.onPlayerWin();
            _uiManager.win();
            Destroy(this.gameObject);

            _player.deleteItems();
            
        }
    }
}
