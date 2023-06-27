using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar_Script : MonoBehaviour
{
    [SerializeField]
    private Slider _shieldTimeSlider;

    /***[SerializeField]
    private MeshRenderer _shield;**/

    [SerializeField]
    private Image _fill;

    [SerializeField]
    private Image _border;

    public void setMaxTime (int time)
    {
        _shieldTimeSlider.maxValue = time;
        _shieldTimeSlider.value = time;
    }

    public void updateTime (int time) 
    {
        _shieldTimeSlider.value = time;
    }

    public void showMesh() 
    {
        //_shield.enabled = true;
        _fill.enabled = true;
        _border.enabled = true;
    }

    public void hideMesh()
    {
        //_shield.enabled = false;
        _fill.enabled = false;
        _border.enabled = false;
    }
}
