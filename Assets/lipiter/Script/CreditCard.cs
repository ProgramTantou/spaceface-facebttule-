using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCard : MonoBehaviour
{
    float PushL1 = 0;//L1‚ª‰Ÿ‚³‚ê‚Ä‚¢‚éŠÔ‚±‚ê‚ªƒIƒ“‚É

    int cnt = 100;//‚±‚ê‚ª‚O‚É‚È‚Á‚Ä‚©‚çƒ{ƒ^ƒ“‚ğ‰Ÿ‚·‚Æíœ
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
