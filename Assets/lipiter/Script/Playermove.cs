using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    static public int hp1 = 5;//1Pの体力

    public float vx=0;
    public float vy=0;
    public float vx2 = 0;
    public float vy2 = 0;
    public float speed = 0.01f;
    public float on = 0;//L1が押されたらこれを増やす。
    public float onc = 0;
    public int cnt=60;//弾のクールタイム

    public float keyR = 0;//キーの入力方向。右。
    public float keyL = 0;//キーの入力方向。左。

    public string tag;

    public GameObject gameObject;

    Rigidbody rigidbody;

    [SerializeField] private Transform _self;

    [SerializeField] private Transform _target;

    [SerializeField] GameObject sphere;

    [SerializeField] GameObject childObj;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        childObj = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        vx = 0;
        vx = Input.GetAxisRaw("HorizontalL") * -0.5f;
        vy = Input.GetAxisRaw("VerticalL") * 0.5f;
        on = Input.GetAxisRaw("P1L1");

        _self.LookAt(_target, Vector3.forward); ;

        if (onc==0)
        {
            onc = on;
            if(on>0)
            {
                cnt = 60;
                GameObject ball = (GameObject)Instantiate(sphere, childObj.transform.position, Quaternion.identity);
                Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
                ballRigidbody.AddForce(transform.forward * 3000);
            }   
        }

        if (on > 0)
        {
            cnt = 10;
        }

            if (cnt>0)
        {
            cnt -= 1;
        }

        if(cnt<=0)
        {
            onc = 0;
        }

        vx2 = Input.GetAxisRaw("HorizontalR") * -0.5f;
        vy2 = Input.GetAxisRaw("VerticalR") * 0.5f;

        /*if(Input.GetKey("P1L1"))
        {
            Instantiate(gameObject);
        }*/

        rigidbody.AddForce(new Vector3(vx+vx2 , vy+vy2, 0), ForceMode.Impulse);

        if (hp1 <= 0)
        {
            Destroy(this. gameObject);
        }

}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag==tag)
        {
            hp1 -= 1;
        }
    }
}
