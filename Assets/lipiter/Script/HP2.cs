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
        slider.maxValue = Player2move.hp2;//hp2�����
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Player2move.hp2;
    }
}
