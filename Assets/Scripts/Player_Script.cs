using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] 
    private ShieldBar_Script _timeBar;
    private int _maxTime = 30000;
    private int _currentTime;

    /**private float _colorChannel = 1f;
    [SerializeField]
    private Material _firstMat;
    [SerializeField]
    private Material _secondMat;
    private Material[] _otherMaterial = new Material[] {_firstMat, _secondMat};
    private MaterialPropertyBlock _mpb;**/

    void Start()
    {
        //show amount of lives in beginning and set player at start position
        _uiManager.updateLives(_lives);
        transform.position = new Vector3(0f, 0f, 0f);
        _currentTime = _maxTime;
        _timeBar.setMaxTime(_maxTime);
        /*** SET MATERIAL
        if (_mpb == null)
        {
            _mpb = new MaterialPropertyBlock();
            _mpb.Clear();
        }***/

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

        _currentTime--;
        _timeBar.updateTime(_currentTime);
        if (_currentTime <= 0)
        {
            gameOver();
        }
        //if no lives left, die
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

        //teleport the player back after falling down
        if (transform.position.y < -10f) 
        {
            transform.position = new Vector3(0f, 2f, 0f); 
            _lives--;
            _uiManager.updateLives(_lives);
        }
    }

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

    /***public void changeColor () 
    {
        // CHANGE MATERIAL
       _colorChannel -= 0.5f;
        _mpb.SetColor("_Color", new Color(_colorChannel, 0, _colorChannel, 1f));
        this.GetComponent<Renderer>().SetPropertyBlock(_mpb); 

        MeshRenderer my_renderer = GetComponent<MeshRenderer>();
        my_renderer.material = other_material[0];
    }***/
}
