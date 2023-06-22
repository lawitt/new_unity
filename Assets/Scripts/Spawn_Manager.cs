using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    //spawn new enemies after certain amount of time
    
    [SerializeField]
    private GameObject _enemyPrefab;
    private float _delay = 1f;

    private bool _alive = true;
    private bool _win = false;

    [SerializeField]
    private UI_Script _uiManager;

    void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    //changes status of player to death
    public void onPlayerDeath()
    {
        _alive = false;
        _uiManager.gameOver();
    }

    public void onPlayerWin()
    {
        _win = true;
    }

    //spawns new enemies as long as player is alive
    IEnumerator SpawnSystem() 
    {
        while(_alive && !_win)
        {
            Instantiate(_enemyPrefab, transform.position + new Vector3(Random.Range(-10f, 10f), 10f, 0f), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delay);
        }
    }
}
