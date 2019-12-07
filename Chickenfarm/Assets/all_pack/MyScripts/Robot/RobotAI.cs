using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotAI : MonoBehaviour {

    [SerializeField] SYSTEM_APP systems; // Основной скрипт игры
    public Animator animator; // Система анимаций
    [SerializeField] NavMeshAgent nav; // Система навигации
    //[SerializeField] Text stuffText;
    [SerializeField] int stuffTotal = 250;
    [HideInInspector] public int do_index; // Индекс в массиве, какую точку будем достигать
    [HideInInspector] public bool goRobot; // Движение true/false
    public Transform[] points; // Координаты точек
    bool collisionOff = false; // Вкл-выкл коллизий
    Rigidbody rigidBody;
    AudioSource audioSource;
    //enum State {Playing,Dead,NextLevel} // В каком состоянии робот
    enum State {Cleaning,Idle,Wait,Walk}
    State state = State.Walk;

    void Start()
    {
        state = State.Walk;
        rigidBody = GetComponent<Rigidbody>(); // Get self rigitbody
        audioSource = GetComponent<AudioSource>();
        //state = State.Playing;
        //energyText.text = energyTotal.ToString();
    }

    public IEnumerator end(GameObject obj)
    {
        yield return new WaitForSeconds(10.3f);
        obj.SetActive(false);
        do_index = 6;
        print("Робот возвращается");
        goRobot = true;
    }

    public IEnumerator wait(GameObject obj)
    {
        yield return new WaitForSeconds(2.3f);
        obj.SetActive(false);
        //animator.SetBool("Roll_Anim", true);
    }

    public Transform Target;
    public float Speed;
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

            if(state == State.Walk){
                Debug.Log("Тут-3");
                //Launch(); // Метод взлета ракеты
                //Rotation(); // Метод поворачивает ракету
                //Cleaning(1, collision.gameObject);
            }
        }
        else{
            animator.SetBool("Roll_Anim", false);
            animator.SetBool("Walk_Anim", false);
            animator.SetBool("Open_Anim", true);
        }

        /*if(state == State.Walk){
        Debug.Log("Тут-3");
        //Launch(); // Метод взлета ракеты
        //Rotation(); // Метод поворачивает ракету
        Cleaning(1, collision.gameObject);
        }*/
    }

    void OnCollisionEnter(Collision collision) // Ф-ция обработки коллизий Cleaning,Idle,Wait,Walk
    {
        //if(state == State.Cleaning || state == State.Idle || collisionOff)
        //{
        //    return; // Функция не обрабатывается дальше
        //}
        Debug.Log("Тут-4");
        switch (collision.gameObject.tag)
        {
            // Проверка с чем соприкасается робот
            //case "Frendly":
            //    print("OK");
            //    break;
            //case "Finish":
            //    Finish();
            //    break;
            case "Stuff":
                //PlusEnergy(1000, collision.gameObject);
                //print("Найден кал");
                Cleaning(1, collision.gameObject);
                break;
            default:
                //Lose();
                break;
        }
    }

    void Cleaning(int stuffToAdd, GameObject clearObj)
    {
        clearObj.GetComponent<BoxCollider>().enabled = false; // Отключаем компоненент коллайдер после первого касания
        stuffTotal += stuffToAdd;
        //stuffText.text = stuffTotal.ToString();
        Destroy(clearObj,0); // Удаление объекта с задержкой
    }

    /*void PlusEnergy(int energyToAdd, GameObject batteryObj)
    {
        batteryObj.GetComponent<BoxCollider>().enabled = false; // Отключаем компоненент коллайдер после первого касания
        energyTotal += energyToAdd;
        energyText.text = energyTotal.ToString();
        Destroy(batteryObj,0); // Удаление объекта с задержкой
    }*/

    /*void Lose()
    {
        state = State.Dead;
        audioSource.Stop(); // Для отключения наложения звуков
        audioSource.PlayOneShot(boomSound);
        boomParticles.Play();
        print("RocketBoom");
        Invoke("LoadFirstLevel",2.5f); 
    }*/


}
