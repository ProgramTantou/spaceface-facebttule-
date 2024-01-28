using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowTo : MonoBehaviour
{
    float PushL1 = 0;//L1が押されている間これがオンに

    int cnt = 100;//これが０になったらボタンを押せる

    public static bool on = false;//カードが出ているあいだはオンに

    public GameObject howto;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PushL1 = Input.GetAxisRaw("P2L2");

        if (!on && cnt > -0)
            cnt -= 1;
    }

    private void OnTriggerStay(Collider other)
    {
        if (PushL1 > 0 && !on && cnt <= 0)
        {
            Instantiate(howto, new Vector3(267, 149, 20), Quaternion.Euler(90, 0, 0));
            cnt = 100;
            on = true;
        }
    }
}