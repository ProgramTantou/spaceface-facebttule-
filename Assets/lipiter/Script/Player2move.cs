using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2move : MonoBehaviour
{
    // Start is called before the first frame update
    static public int hp2 = 5;

    public float vx = 0;
    public float vy = 0;
    public float vx2 = 0;
    public float vy2 = 0;
    public float speed = 0.01f;
    public float on = 0;//L1が押されたらこれを増やす。
    public float onc = 0;
    public int cnt = 60;//弾のクールタイム

    public string tagname;

    public float keyR = 0;//キーの入力方向。右。
    public float keyL = 0;//キーの入力方向。左。
    public GameObject face;
    SkinnedMeshRenderer skinnedMeshRenderer;
    float blendr;
    float blendl;
    float blendu;
    float blendd;
    CapsuleCollider c;
    float cstartheight;
    float cstartradius;
    Vector3 bulletstartscale;

    //  public GameObject gameObject;

    Rigidbody rigidbody;

    [SerializeField] private Transform _self;

    [SerializeField] private Transform _target;

    [SerializeField] GameObject sphere2;

    [SerializeField] GameObject childObj2;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        childObj2 = transform.GetChild(0).gameObject;
        skinnedMeshRenderer = face.GetComponent<SkinnedMeshRenderer>();
        c = this.GetComponent<CapsuleCollider>();
        cstartheight = c.height;
        cstartradius = c.radius;
        bulletstartscale = new Vector3(2, 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
        vx = 0;
        vx = Input.GetAxisRaw("HorizontalL2") * -0.5f;
        vy = Input.GetAxisRaw("VerticalL2") * 0.5f;
        on = Input.GetAxisRaw("P1L1");

        _self.LookAt(_target, new Vector3(0, 0, 1));

        if (onc == 0)
        {
            onc = on;
            if (on > 0)
            {
                cnt = 60;
                GameObject ball2 = (GameObject)Instantiate(sphere2, childObj2.transform.position, Quaternion.Euler(90, 0, 0));
                ball2.GetComponent<Bullet1>().transform.rotation = childObj2.transform.rotation;
                Rigidbody ball2Rigidbody = ball2.GetComponent<Rigidbody>();
                ball2Rigidbody.AddForce(transform.forward * 3000);
            }
        }

        if (on > 0)
        {
            cnt = 10;
        }

        if (cnt > 0)
        {
            cnt -= 1;
        }

        if (cnt <= 0)
        {
            onc = 0;
        }

        vx2 = Input.GetAxisRaw("HorizontalR2") * -0.5f;
        vy2 = Input.GetAxisRaw("VerticalR2") * 0.5f;

        /*if(Input.GetKey("P1L1"))
        {
            Instantiate(gameObject);
        }*/

        rigidbody.AddForce(new Vector3(vx + vx2, vy + vy2, 0), ForceMode.Impulse);
        if (vx == 0 && vx2 == 0)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
            skinnedMeshRenderer.SetBlendShapeWeight(1, 0);
            blendr = 0;
            blendl = 0;
            Debug.Log("reset!");
            c.radius = cstartradius;
            sphere2.transform.localScale = bulletstartscale;
        }
        if (vx < 0 && vx2 > 0)
        {
            blendl = blendl - vx;
            skinnedMeshRenderer.SetBlendShapeWeight(1, vx * blendl);
            blendr = blendr - vx2;
            skinnedMeshRenderer.SetBlendShapeWeight(0, vx2 * blendr);
            Debug.Log("shrink!");
            c.radius = c.radius - .003f;
            sphere2.transform.localScale = bulletstartscale;
        }
        else
        {
            if (vx > 0 && vx2 < 0)
            {
                Debug.Log("grow!");
                c.radius = c.radius + .001f;
                sphere2.transform.localScale += new Vector3(.002f, .002f, .002f);
            }
            if (vx < 0)
            {
                blendr = blendr + vx;
                skinnedMeshRenderer.SetBlendShapeWeight(0, vx * blendr);
                Debug.Log("right!");
            }

            if (vx > 0)
            {
                blendl = blendl + vx;
                skinnedMeshRenderer.SetBlendShapeWeight(1, vx * blendl);
                Debug.Log("left!");
            }
            if (vx2 < 0)
            {
                blendr = blendr + vx2;
                skinnedMeshRenderer.SetBlendShapeWeight(0, vx2 * blendr);
                Debug.Log("right2!");
            }
            if (vx2 > 0)
            {
                blendl = blendl + vx2;
                skinnedMeshRenderer.SetBlendShapeWeight(1, vx2 * blendl);
                Debug.Log("left2!");
            }

        }
        if (vy == 0 && vy2 == 0)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(2, 0);
            skinnedMeshRenderer.SetBlendShapeWeight(3, 0);
            blendu = 0;
            blendd = 0;
            Debug.Log("reset!");
            c.height = cstartheight;
            sphere2.transform.localScale = bulletstartscale;
        }
        if (vy < 0 && vy2 > 0)
        {
            blendu = blendu - vy;
            skinnedMeshRenderer.SetBlendShapeWeight(3, vy * blendu);
            blendd = blendd - vy2;
            skinnedMeshRenderer.SetBlendShapeWeight(2, vy2 * blendd);
            Debug.Log("shrink2!");
            c.height = c.height - .003f;
            sphere2.transform.localScale = bulletstartscale;
        }
        else
        {
            if (vy > 0 && vy2 < 0)
            {
                
                c.radius = c.radius + .002f;
                sphere2.transform.localScale += new Vector3(.002f, .002f, .002f);
            }
            if (vy < 0)
            {
                blendd = blendd - vy;
                skinnedMeshRenderer.SetBlendShapeWeight(3, -vy * blendd);
                Debug.Log("down!");
            }
            if (vy > 0)
            {
                blendu = blendu + vy;
                skinnedMeshRenderer.SetBlendShapeWeight(2, vy * blendu);
                Debug.Log("up!");
            }
            if (vy2 < 0)
            {
                blendd = blendd - vy2;
                skinnedMeshRenderer.SetBlendShapeWeight(3, -vy2 * blendd);
                Debug.Log("down2!");
            }
            if (vy2 > 0)
            {
                blendu = blendu + vy2;
                skinnedMeshRenderer.SetBlendShapeWeight(2, vy2 * blendu);
                Debug.Log("up2!");
            }
        }

        if (hp2 <= 0)
        {
            Destroy();
            //Destroy(this.gameObject);
            
        }

    }
    public void Destroy()
    {
        this.gameObject.SetActive(false);
        Debug.Log("Hp0");
    }
 

private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagname)
        {
            Debug.Log("HIT");
            hp2 -= 1;
        }
    }
}