using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    

    float PushL1 = 0;//L1が押されている間これがオンに
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PushL1 = Input.GetAxisRaw("P2L2");
    }

    private void OnTriggerStay(Collider other)
    {
        if(PushL1>0)
        {
            SceneManager.LoadScene("facebattle");
        }
    }
}
