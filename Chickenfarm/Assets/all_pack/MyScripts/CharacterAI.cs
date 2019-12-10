using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAI : MonoBehaviour {

    [SerializeField] SYSTEM_APP systems; // Система игры
    public Animator animator; // Система анимаций
    [SerializeField] NavMeshAgent nav; // Система навигации

    [HideInInspector]
    public int do_index; // Индекс в массиве, какую точку будем достигать
    [HideInInspector]
    public bool go; // Движение


    public IEnumerator end(GameObject obj)
    {
        yield return new WaitForSeconds(2.3f);
        obj.SetActive(false);
        //animator.SetTrigger("work"); // Анимация стояния
        animator.SetBool("walk", true); // Анимация ходьбы
        nav.destination = points[5].position;
    }

    public Transform[] points; // точки к которым перемещается персонаж

    void Update () 
    { // Обработка каждый кадр
		if(go) // Включили движение персонажа к объектам
        {
            nav.destination = points[do_index - 1].position; // Точки, цели в массиве points
            if (Vector3.Distance(transform.position, points[do_index - 1].position) < 0.6f) // Если дистанция между обьектом и персонажем меньше 0.6 то включаем анимацию
            {
                //animator.SetTrigger("work"); // Анимация работы
                animator.SetBool("walk", false); // Анимация покоя
                animator.SetTrigger("work"); // Анимация стояния
                go = false;

                if (do_index == 1)
                    //StartCoroutine(end(systems.WaterLamp)); // Анимация поить
                    systems.WaterLampRed.SetActive(false); // Выключаем красный свет
                if (do_index == 2)
                    //StartCoroutine(end(systems.WaterLamp)); // Анимация кормить
                    systems.EatLamp.SetActive(false); // Выключаем синий свет

                if (do_index == 3)
                    StartCoroutine(end(systems.Clear)); // Выключаем clear через 1.3 сек

                if (do_index == 4)
                // Собираем яйца
                    StartCoroutine(end(points[do_index - 1].gameObject)); // Выключаем яйцо через 1.3 сек

            }
        }
	}
}