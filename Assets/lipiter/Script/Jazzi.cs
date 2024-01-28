using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jazzi : MonoBehaviour
{
    public GameObject win1;
    public GameObject win2;

    float w;
    float s;

    int cnt = 1200;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Playermove.hp1<=0)
        {
            Instantiate(win1, new Vector3(-87, 114, 20), Quaternion.Euler(90, 0, 0));
            w = Input.GetAxisRaw("P2L2");
            s = Input.GetAxisRaw("P1L1");
            if(w>0 || s>0)
            {
                SceneManager.LoadScene("Title");
            }
        }

        if (Player2move.hp2 <= 0)
        {
            Instantiate(win2, new Vector3(-87, 114, 20), Quaternion.Euler(90, 0, 0));
            w = Input.GetAxisRaw("P2L2");
            s = Input.GetAxisRaw("P1L1");
            if (w > 0 || s > 0)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
