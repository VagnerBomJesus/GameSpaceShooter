using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrasVidas : MonoBehaviour
{
    public PlayerController playerController;

    public Slider sliderBar;

    private void Start()
    {
        sliderBar.wholeNumbers = true;
        sliderBar.minValue = 0;


    }
    private void Update()
    {
       // sliderBar.maxValue = playerController.stats.max
    }

}
