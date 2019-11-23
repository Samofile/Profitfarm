using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAI : MonoBehaviour {

    public Animator animator; // Система анимаций

    [SerializeField] NavMeshAgent nav; // Система навигации

    public Transform[] points; // координаты точек куда персонаж будет ходить(колодец, миска, курица и тд)

    [HideInInspector]
    public int do_index; // индекс в массиве, какую точку будем достигать (выше)

    [HideInInspector]
    public  bool go;

    [SerializeField] SYSTEM_APP systems; // Система игры

    public IEnumerator end(GameObject obj)
    {
        yield return new WaitForSeconds(10.3f);
        obj.SetActive(false);
    }

	void Update () { // Обработка на каждый кадр
		if(go)
        {
            nav.destination = points[do_index - 1].position; // Достигаем обьект в массиве points
            if (Vector3.Distance(transform.position, points[do_index - 1].position) < 0.6f) // Если дистанция между обьектом и персонажем меньше 0.6 то включаем анимацию
            {
                animator.SetTrigger("work"); // Анимация (ВЗЯТЬ)
                go = false;
                animator.SetBool("walk", false); // Анимация стойки на месте

                if (do_index == 3)
                    StartCoroutine(end(systems.kal)); // Выключаем какашки через 1.3 сек

                if (do_index == 4)
                    StartCoroutine(end(points[do_index - 1].gameObject)); // Выключаем яйцо через 1.3 сек
            }
        }
	}
}
