using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotAI : MonoBehaviour {

    [SerializeField] SYSTEM_APP systems; // Основной скрипт игры
    public Animator animator; // Система анимаций
    [SerializeField] NavMeshAgent nav; // Система навигации

    [HideInInspector]
    public int do_index; // Индекс в массиве, какую точку будем достигать
    [HideInInspector]
    public bool goRobot; // Движение true/false


    public IEnumerator end(GameObject obj)
    {
        yield return new WaitForSeconds(10.3f);
        obj.SetActive(false);
        do_index = 6;
        print("Робот возвращается");
        goRobot = true;
    }

    public Transform[] points; // координаты точек куда персонаж будет перемещаться (колодец, миска, курица и тд)

    public IEnumerator wait(GameObject obj)
    {
        yield return new WaitForSeconds(2.3f);
        obj.SetActive(false);
        //animator.SetBool("Roll_Anim", true);
    }

    public Transform Target;
    public float Speed;
    [Tooltip("Как близко приближаться к Target")]
    public float RelaxDistance;

    void Update () { // Обработка каждый кадр

        if(goRobot)
        {
            print(do_index);
            animator.SetBool("Roll_Anim", true);
            //animator.SetBool("Walk_Anim", true);

            nav.destination = points[do_index - 1].position; // Достигаем обьект в массиве points

            if (Vector3.Distance(transform.position, points[do_index - 1].position) < 0.6f) // Если дистанция между обьектом и персонажем меньше 0.6 то включаем анимацию
            {
                goRobot = false;
                //animator.SetBool("Walk_Anim", true); // Анимация покоя

                if (do_index == 3)
                {
                    StartCoroutine(end(systems.Clear)); // Выключаем clear через 1.3 сек
                    animator.SetBool("Roll_Anim", false);
                    animator.SetBool("Walk_Anim", false);
                    animator.SetBool("Open_Anim", true);
                    print("Робот на объекте");
                }

                if (do_index == 6)
                {
                    animator.SetBool("Roll_Anim", false);
                    animator.SetBool("Walk_Anim", false);
                    animator.SetBool("Open_Anim", true);
                }


            }
        }

        // Move robot to object
        var dir = Target.position - transform.position;
        if (dir.sqrMagnitude > RelaxDistance * RelaxDistance)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
            transform.LookAt(Target);
            animator.SetBool("Roll_Anim", false);
            animator.SetBool("Walk_Anim", true);
            animator.SetBool("Open_Anim", false);
        }
        else{
            animator.SetBool("Roll_Anim", false);
            animator.SetBool("Walk_Anim", false);
            animator.SetBool("Open_Anim", true);
        }
    }
}
