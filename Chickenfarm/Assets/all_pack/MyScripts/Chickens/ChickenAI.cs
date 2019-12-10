using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAI : MonoBehaviour
{
    public Transform Target;
    public Transform eatTarget;
    public float Speed;
    public float RelaxDistance;
    [SerializeField] UnityEngine.AI.NavMeshAgent navi; // Система навигации
    public Animator animator; // Система анимаций
    public Transform newChicken; // Объект сам на себя
    public GameObject newClear;

    void Start()
    {
        animator.Play("walk");
        StartCoroutine(MakeClear(30f));
        //animator.enabled = true;
        //animator.SetBool("idle", true);
        //animator.SetBool("dead", false);
        //animator.SetBool("run", false);
        //animator.SetBool("sleep", false);
        //animator.SetBool("walk", false);
    }

    void Update()
    {
        if (Menu.doDrink){
            transform.LookAt(eatTarget); // Move chickens to Drink object
            var dir1 = eatTarget.position - transform.position;
            if (dir1.sqrMagnitude > RelaxDistance * RelaxDistance)
            {
                float step = Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, eatTarget.position, step);
                transform.LookAt(eatTarget);
            }else{
                transform.LookAt(Target); // Move chickens to Player object
                var dir = Target.position - transform.position;
                if (dir.sqrMagnitude > RelaxDistance * RelaxDistance)
                {
                    float step = Speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
                    transform.LookAt(Target);
                    //transform.position = Vector3.Distance(Target.position, transform.position);
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
        }
        

    }

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
