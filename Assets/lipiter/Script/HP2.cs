using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP2 : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = Playermove.hp1;//hp2ÇçÏÇÈ
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Playermove.hp1;
    }
}
