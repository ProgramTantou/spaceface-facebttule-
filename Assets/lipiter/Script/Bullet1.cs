using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{

    public int cnt = 600;//���ꂪ�O�ɂȂ�����I�u�W�F�N�g�������B
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cnt -= 300;
        if(cnt<=0)
        {
            Destroy(this);
        }
    }
}
