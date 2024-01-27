using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casol : MonoBehaviour
{
    public float vx = 0;
    public float vy = 0;
    public float vx2 = 0;
    public float vy2 = 0;

    public GameObject gameObject;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vx = Input.GetAxisRaw("HorizontalL") * -0.5f;
        vy = Input.GetAxisRaw("VerticalL") * 0.5f;
        vx2 = Input.GetAxisRaw("HorizontalR") * -0.5f;
        vy2 = Input.GetAxisRaw("VerticalR") * 0.5f;

        rigidbody.AddForce(new Vector3(vx + vx2, vy + vy2, 0), ForceMode.Impulse);
    }
}
