using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton_Script : MonoBehaviour
{
    //when you click on the button, the color of the player changes
    [SerializeField]
    private GameObject _player; 

    //assign the different possible colors
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

    void Start ()
    {
        _otherMaterial.Add(_firstMat);
        _otherMaterial.Add(_secondMat);
        _otherMaterial.Add(_thirdMat);
        _otherMaterial.Add(_fourthMat);
        _otherMaterial.Add(_fifthMat);
    }

    //change the color and save it in PlayerPrefs
    public void changeColor () 
    {
        _index++;
        if (_index >= 5)
        {
            _index = 0;
        }
        _player.GetComponent<Renderer>().material = _otherMaterial[_index];

        PlayerPrefs.SetInt("MaterialKey", _index);
    }
}
