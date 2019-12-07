using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //animator.enabled = true;
        //animator.SetBool("idle", true);
        //animator.SetBool("dead", false);
        //animator.SetBool("run", false);
        //animator.SetBool("sleep", false);
        //animator.SetBool("walk", false);
        animator.Play("walk");
        //animator.Pl
        StartCoroutine(MakeClear(6f));
    }

    public Transform Target;
    public float Speed;
    [Tooltip("Как близко приближаться к Target")]
    public float RelaxDistance;
    [SerializeField] UnityEngine.AI.NavMeshAgent navi; // Система навигации
    public Animator animator; // Система анимаций


    // Update is called once per frame
    void Update()
    {
        // Move chickens to object
        transform.LookAt(Target);
        var dir = Target.position - transform.position;
        if (dir.sqrMagnitude > RelaxDistance * RelaxDistance)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
            //transform.position = Vector3.Distance(Target.position, transform.position);
            transform.LookAt(Target);
            //animator.SetBool("Roll_Anim", false);
            //animator.SetBool("Walk_Anim", true);
            //animator.SetBool("Open_Anim", false);
        }
        else{
            //animator.SetBool("Roll_Anim", false);
            //animator.SetBool("Walk_Anim", false);
            //animator.SetBool("Open_Anim", true);
            //animator.SetBool("idle", true);
            //animator.SetBool("dead", false);
            //animator.SetBool("run", false);
            //animator.SetBool("sleep", false);
            //animator.SetBool("walk", false);
        }
    }


    public Transform newChicken; // Объект сам на себя
    public GameObject newClear;

    private IEnumerator MakeClear(float value)
    {
        while (true)
        {
        yield return new WaitForSeconds(20f);
        Vector3 pos = newChicken.transform.position;
        GameObject nextClear = Instantiate(newClear, new Vector3(pos.x, pos.y, pos.z), transform.rotation);
        nextClear.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        nextClear.SetActive(true);
        value = value + 20;
        yield return new WaitForSeconds(value);
        }
    }
}
