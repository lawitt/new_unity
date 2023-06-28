using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar_Script : MonoBehaviour
{   
    //time bar shows the time, the protective shield is still active before it gets destroied or until time of whole game is over
    [SerializeField]
    private Slider _shieldTimeSlider;

    [SerializeField]
    private Image _fill;

    [SerializeField]
    private Image _border;

    //set a maximum of time
    public void setMaxTime (int time)
    {
        _shieldTimeSlider.maxValue = time;
        _shieldTimeSlider.value = time;
    }

    //update the time in bar
    public void updateTime (int time) 
    {
        _shieldTimeSlider.value = time;
    }

    //show the bar after activating the shield
    public void showMesh() 
    {
        _fill.enabled = true;
        _border.enabled = true;
    }

    //hide the bar, after time is up
    public void hideMesh()
    {
        _fill.enabled = false;
        _border.enabled = false;
    }
}
