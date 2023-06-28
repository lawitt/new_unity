using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{
    //player jumps through the environment of the game and tries to reach the goal
    
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

    [SerializeField] 
    private TimeBar_Script _timeBar;
    [SerializeField]
    private int _maxTime = 10000; //time the player has to win the game
    private int _currentTime;

    //get the different materials to change color
    [SerializeField]
    private Material _firstMat;
    [SerializeField]
    private Material _secondMat;
    [SerializeField]
    private Material _thirdMat;
    [SerializeField]
    private Material _fourthMat;
    [SerializeField]
    private Material _fifthMat;

    List<Material> _otherMaterial = new List<Material>();
    private int _index = 0;

    void Start()
    {
        //show amount of lives in beginning
        _uiManager.updateLives(_lives);
        //set player at start position
        transform.position = new Vector3(0f, 0f, 0f);
        //start the time bar
        _currentTime = _maxTime;
        _timeBar.setMaxTime(_maxTime);

        changeToColor();
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

        //update the time bar
        _currentTime--;
        _timeBar.updateTime(_currentTime);

        //when time is over, game over
        if (_currentTime <= 0)
        {
            gameOver();
        }

        //if no lives left, game over
        if(_lives <= 0)
        {
            gameOver();
        }
    }

    //function to react after got damaged
    public void damage()
    {
        //loses a live and update UI
        _lives --;
        _uiManager.updateLives(_lives);
        Debug.Log("Damage"+ _lives);
    }

    //function to receive axtra live, after eating bird and update UI
    public void recovery() 
    {
        _lives++;
        _uiManager.updateLives(_lives);
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

        //teleport the player back after falling down and losing a live
        if (transform.position.y < -10f) 
        {
            transform.position = new Vector3(0f, 2f, 0f); 
            damage();
        }
    }

    //when time is up or lost last live, the player lost and game Over is shown
    void gameOver () 
    {
        if(SpawnManager != null)
        {
            //remove player object
            SpawnManager.GetComponent<Spawn_Manager>().onPlayerDeath();
            deleteItems();
            SceneManager.LoadScene("GameOverScene");
            Debug.Log("Death");
            Destroy(this.gameObject);
        }
    }

    //change material to the chosen one
    void changeToColor ()
    {
        _otherMaterial.Add(_firstMat);
        _otherMaterial.Add(_secondMat);
        _otherMaterial.Add(_thirdMat);
        _otherMaterial.Add(_fourthMat);
        _otherMaterial.Add(_fifthMat);

        _index = PlayerPrefs.GetInt("MaterialKey", 0);
        GetComponent<Renderer>().material = _otherMaterial[_index];
    }

}
