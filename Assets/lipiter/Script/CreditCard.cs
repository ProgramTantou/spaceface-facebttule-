using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCard : MonoBehaviour
{
    float PushL1 = 0;//L1が押されている間これがオンに

    int cnt = 100;//これが０になってからボタンを押すと削除
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PushL1 = Input.GetAxisRaw("P2L2");

        cnt -= 1;

        if(PushL1>0 && cnt<=0)
        {
            Credit.on = false;
            Destroy(this. gameObject);
        }
    }
}
