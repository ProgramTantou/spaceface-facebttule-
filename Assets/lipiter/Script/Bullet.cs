using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public Transform _self;

    public Transform _target;

    public int cnt = 3000;//これが０になったらオブジェクトを消す。ody;

    Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
       // rbody=this.GetComponent;
        _self.LookAt(_target.transform, Vector3.forward); 
    }

    // Update is called once per frame
    void Update()
    {
        cnt -= 1;
        if(cnt<=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
