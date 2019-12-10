using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsAI : MonoBehaviour
{
    public Transform Target;
    public float Speed;
    public float RelaxDistance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.staticEggCount == "0") {
            //Menu.staticEggCount = "0";
            transform.LookAt(Target); // Move eggs to refregerator
            var dir = Target.position - transform.position;
            if (dir.sqrMagnitude > RelaxDistance * RelaxDistance)
            {
                float step = Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
                //transform.LookAt(Target);
            }
        }else{
            Debug.Log("Eggs is here");
        }

    }
}
