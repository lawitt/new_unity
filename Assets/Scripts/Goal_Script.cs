using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Script : MonoBehaviour
{
    //When the goal of the game get catched, the player wins the game
    [SerializeField] 
    private Spawn_Manager _spawnManager;

    [SerializeField]
    private Player_Script _player;

    // when player collides with goal, the player wins
    void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            _spawnManager.onPlayerWin();
            _player.deleteItems();
            Destroy(this.gameObject);
        }
    }
}
