using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    //spawn new enemies after certain amount of time
    
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _delayEnemy = 1f;

    private bool _alive = true;
    private bool _win = false;

    [SerializeField]
    private UI_Script _uiManager;

    [SerializeField]
    private float _height;

    void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    //changes status of player to death
    public void onPlayerDeath()
    {
        _alive = false;
    }

    //when player won, set win true, so no new enemies are spawn
    public void onPlayerWin()
    {
        _win = true;
    }

    //spawns new enemies as long as player is alive
    IEnumerator SpawnSystem() 
    {
        while(_alive && !_win)
        {
            Instantiate(_enemyPrefab, transform.position + new Vector3(Random.Range(-20f, 20f), _height, 0f), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delayEnemy);
        }
    }
}
