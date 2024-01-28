using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP1 : MonoBehaviour
{
    float HP = 1000;
    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value=Playermove.hp1;
    }
}
