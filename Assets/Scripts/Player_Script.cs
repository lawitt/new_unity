using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    //player jumps through the environment of the game
    
    //move and jump
    [SerializeField]
    private float _speed = 5f;
    private float _jumpingSpeed = 10f;

    //jump time delay
    private float _nextJumpTime = 0f;
    private float _coolDownTime = 2f;

    //bullet time delay
    private float _nextFireTime = 0f;
    private float _fireCoolDownTime = 0.5f;

    //counter for lives
    private int _lives = 3;

    //UI to show amount of lives
    [SerializeField]
    private UI_Script _uiManager;

    [SerializeField]
    private Rigidbody RB;

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private GameObject SpawnManager;

    void Start()
    {
        //show amount of lives in beginning and set player at start position
        _uiManager.updateLives(_lives);
        transform.position = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        playerMovement();

        //bullet firing
        if (Input.GetKeyDown(KeyCode.X) && _nextFireTime < Time.time)
        {
            Instantiate(_bulletPrefab, transform.position + new Vector3(0f, 0.7f, 0f), Quaternion.identity);
            _nextFireTime = Time.time + _fireCoolDownTime;
        }
    }

    //function to react after got damaged
    public void damage()
    {
        //loses a live and update UI
        _lives --;
        _uiManager.updateLives(_lives);
        Debug.Log("Damage"+ _lives);

        //if no lives left, die
        if(_lives == 0)
        {

            if(SpawnManager != null)
            {
                //remove player object
                SpawnManager.GetComponent<Spawn_Manager>().onPlayerDeath();
                Destroy(this.gameObject);
                Debug.Log("Death");
            }

            deleteItems();
        }

    }

    public void deleteItems() 
    {
        //remove all enemies after death
            foreach(Transform child in SpawnManager.transform)
            {
                Destroy(child.gameObject);
            }
    }

    void playerMovement () 
    {
        //moving to left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * Time.deltaTime * _speed * horizontalInput);

        //jumping when space is pressed adding a certain time delay
        if (Input.GetKeyDown("space") && _nextJumpTime <= Time.time)
        {
            RB.velocity += new Vector3(0f, _jumpingSpeed, 0f);
            _nextJumpTime = Time.time + _coolDownTime;
        }

        //teleport the player back after falling down
        if (transform.position.y < -10f) 
        {
            transform.position = new Vector3(0f, 2f, 0f); 
        }
    }
}
