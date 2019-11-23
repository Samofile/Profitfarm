using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chick : MonoBehaviour
{
    int n;
    float t;
    bool start;

    void Awake()
    {
        t = Random.Range(0f, 1.5f);
        n = Random.Range(2, 10);
    }

    public Animator anim;

    void Update()
    {
        if (!start)
        {
            if (t > 0)
            {
                t -= Time.deltaTime;
            }
            else
            {
                anim.enabled = true;
                start = true;
                t = 0;
            }
        }
        else
        {
            if(t < n)
            {
                t += Time.deltaTime;
            }
            else
            {
                int o = Random.Range(0, 2);
                if(o == 0)
                {
                    anim.SetTrigger("walk");
                }
                if (o == 1)
                {
                    anim.SetTrigger("sleep");
                }
                t = 0;
                n = Random.Range(2, 10);
            }
        }

    }
}
